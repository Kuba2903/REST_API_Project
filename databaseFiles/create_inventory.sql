USE [shop]
GO

/****** Object:  Table [dbo].[inventory]    Script Date: 05.02.2024 18:12:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[inventory](
	[product_id] [int] NOT NULL,
	[sku] [char](16) NOT NULL,
	[unit] [varchar](100) NULL,
	[qty] [smallint] NULL,
	[manufacturer] [varchar](200) NULL,
	[ship_time] [varchar](200) NULL,
	[ship_cost] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC,
	[sku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[inventory]  WITH CHECK ADD FOREIGN KEY([product_id], [sku])
REFERENCES [dbo].[products] ([id], [sku])
GO

