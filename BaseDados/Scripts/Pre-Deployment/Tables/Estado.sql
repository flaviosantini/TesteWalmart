-- =============================================
-- Script Template
-- =============================================
USE [Walmart]
GO

/****** Object:  Table [dbo].[ESTADO]    Script Date: 05/28/2013 21:33:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ESTADO](
	[COD_ESTADO] [int] NOT NULL,
	[PAIS] [varchar](50) NULL,
	[NOME] [varchar](50) NULL,
	[SIGLA] [char](2) NOT NULL,
	[REGIAO] [varchar](50) NULL,
 CONSTRAINT [PK_ESTADO] PRIMARY KEY CLUSTERED 
(
	[COD_ESTADO] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

