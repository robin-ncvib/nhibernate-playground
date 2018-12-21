SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Person](
	[PersonId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [Inspection].[PostInspection](
	[PostInspectionId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[ContactPersonId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_PostInspection] PRIMARY KEY CLUSTERED 
(
	[PostInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [Inspection].[PostInspectionPerson](
	[PersonId] [uniqueidentifier] NOT NULL,
	[PostInspectionId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PostInspectionPerson] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC,
	[PostInspectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
