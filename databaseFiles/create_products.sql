USE [shop]
GO

/****** Object:  Table [dbo].[products]    Script Date: 05.02.2024 18:10:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[products](
	[id] [int] NOT NULL,
	[sku] [char](16) NOT NULL,
	[name] [varchar](300) NULL,
	[ean] [char](13) NULL,
	[producer_name] [varchar](100) NULL,
	[category] [varchar](100) NULL,
	[is_wire] [bit] NULL,
	[is_available] [bit] NULL,
	[is_vendor] [bit] NULL,
	[default_image] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[sku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

