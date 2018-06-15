using System;

namespace NHibernate.Playground.Specifications
{
    internal class ExpectedExceptionException : Exception
    {
        public ExpectedExceptionException(string name, Exception exception = null)
        {
        }
    }
}