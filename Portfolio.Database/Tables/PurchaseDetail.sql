CREATE TABLE [dbo].[PurchaseDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subtotal] [money] NULL,
	[Shipping] [money] NULL,
	[Tax] [money] NULL,
	[Total] [money] NULL,
	[Date] [datetime] NULL,
	[SellerName] [varchar](250) NULL,
	[SellerAddress] [varchar](500) NULL,
	[Quantity] [int] NOT NULL DEFAULT (0),
	[CoinId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PurchaseDetail] ADD  DEFAULT ((0.00)) FOR [Subtotal]
GO

ALTER TABLE [dbo].[PurchaseDetail] ADD  DEFAULT ((0.00)) FOR [Shipping]
GO

ALTER TABLE [dbo].[PurchaseDetail] ADD  DEFAULT ((0.00)) FOR [Tax]
GO

ALTER TABLE [dbo].[PurchaseDetail] ADD  DEFAULT ((0.00)) FOR [Total]
GO
