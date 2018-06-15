USE [NHibernatePlayground]
GO

/****** Object:  Table [dbo].[Forecast]    Script Date: 2018-06-15 14:24:30 ******/
DROP TABLE [dbo].[Forecast]
GO

/****** Object:  Table [dbo].[MeasurementPoint]    Script Date: 2018-06-15 14:24:56 ******/
DROP TABLE [dbo].[MeasurementPoint]
GO

/****** Object:  Table [dbo].[Model]    Script Date: 2018-06-15 14:25:07 ******/
DROP TABLE [dbo].[Model]
GO




/****** Object:  Table [dbo].[MeasurementPoint]    Script Date: 2018-06-15 14:23:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MeasurementPoint](
	[MeasurementPointId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetimeoffset](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MeasurementPointId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Model]    Script Date: 2018-06-15 14:23:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Model](
	[ModelId] [int] NOT NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[ModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO [dbo].[Model] ([ModelId]) VALUES(1)
INSERT INTO [dbo].[Model] ([ModelId]) VALUES(2)
INSERT INTO [dbo].[Model] ([ModelId]) VALUES(3)
INSERT INTO [dbo].[Model] ([ModelId]) VALUES(4)
GO


/****** Object:  Table [dbo].[Forecast]    Script Date: 2018-06-15 14:21:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Forecast](
	[ForecastId] [uniqueidentifier] NOT NULL,
	[ModelId] [int] NOT NULL,
	[MeasurementPointId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ForecastId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Forecast]  WITH CHECK ADD  CONSTRAINT [FK_MeasurementPoint_Forecast] FOREIGN KEY([MeasurementPointId])
REFERENCES [dbo].[MeasurementPoint] ([MeasurementPointId])
GO

ALTER TABLE [dbo].[Forecast] CHECK CONSTRAINT [FK_MeasurementPoint_Forecast]
GO

ALTER TABLE [dbo].[Forecast]  WITH CHECK ADD  CONSTRAINT [FK_Model_Forecast] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Model] ([ModelId])
GO

ALTER TABLE [dbo].[Forecast] CHECK CONSTRAINT [FK_Model_Forecast]
GO


