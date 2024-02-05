USE [shop]
GO

/****** Object:  Table [dbo].[prices]    Script Date: 05.02.2024 18:12:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[prices](
	[id] [int] NOT NULL,
	[sku] [char](16) NOT NULL,
	[net_price] [smallint] NULL,
	[price_after_discount] [smallint] NULL,
	[vat_rate] [tinyint] NULL,
	[price_after_discount_logistic_unit] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[sku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[prices]  WITH CHECK ADD FOREIGN KEY([id], [sku])
REFERENCES [dbo].[products] ([id], [sku])
GO

