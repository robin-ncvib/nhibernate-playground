using System;
using System.Diagnostics;
using System.Transactions;
using NUnit.Framework;

namespace NHibernate.Playground.Specifications
{
    public abstract class ContextSpecification
    {
        protected virtual System.Type ExpectedExceptionType => null;
        protected Exception ActualException { get; set; }

        [OneTimeSetUp]
        [DebuggerStepThrough]
        public void Setup()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
            {
                CreateMocks();
                Givens();
                SetupMockBehaviour();
                InitializeStateOnTestClass();
                SubscibeToEvents();
                VerifyTestData();
                PerformAct();
                GetSavedTestData();
            }
        }

        [OneTimeTearDown]
        [DebuggerStepThrough]
        public void Teardown()
        {
            AfterEachSpecification();
        }

        protected abstract void CreateMocks();

        protected abstract void Givens();

        protected abstract void SetupMockBehaviour();

        protected abstract void InitializeStateOnTestClass();

        protected abstract void When();

        protected virtual void SubscibeToEvents()
        {
        }

        protected virtual void GetSavedTestData()
        {
        }

        [DebuggerStepThrough]
        protected virtual void AfterEachSpecification()
        {
        }

        [DebuggerStepThrough]
        protected virtual void VerifyTestData()
        {
        }

        private void PerformAct()
        {
            if (ExpectedExceptionType == null)
            {
                When();
            }
            else
            {
                try
                {
                    When();
                    throw new ExpectedExceptionException("Expected exception of type: " + ExpectedExceptionType.Name);
                }
                catch (ExpectedExceptionException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    if (e.GetType() != ExpectedExceptionType)
                    {
                        throw new ExpectedExceptionException($"Expected exception of type {ExpectedExceptionType.Name} but received {e.GetType().Name}.", e);
                    }

                    ActualException = e;
                }
            }
        }
    }
}