CREATE TABLE [dbo].[Coin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [varchar](250) NOT NULL,
	[ListPrice] [money] NULL,
	[Description] [varchar](1000) NOT NULL,
	[Quantity] [int] NOT NULL DEFAULT(0),
	[PurchaseDetailId] [int] NULL,
    [DenominationId] INT NULL, 
    [MintId] INT NULL, 
    [GradingCompanyId] INT NULL, 
    [Grade] VARCHAR(50) NULL, 
    [IsForSale] BIT NOT NULL DEFAULT (0), 
    PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Coin]  WITH CHECK ADD  CONSTRAINT [FK_Coin_PurchaseDetail] FOREIGN KEY([PurchaseDetailId])
REFERENCES [dbo].[PurchaseDetail] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Coin] CHECK CONSTRAINT [FK_Coin_PurchaseDetail]
GO

ALTER TABLE [dbo].[Coin]  WITH CHECK ADD  CONSTRAINT [FK_Coin_Denomination] FOREIGN KEY([DenominationId])
REFERENCES [dbo].[Denomination] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Coin] CHECK CONSTRAINT [FK_Coin_Denomination]
GO

ALTER TABLE [dbo].[Coin]  WITH CHECK ADD  CONSTRAINT [FK_Coin_Mint] FOREIGN KEY([MintId])
REFERENCES [dbo].[Mint] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Coin] CHECK CONSTRAINT [FK_Coin_Mint]
GO

ALTER TABLE [dbo].[Coin]  WITH CHECK ADD  CONSTRAINT [FK_Coin_GradingCompany] FOREIGN KEY([GradingCompanyId])
REFERENCES [dbo].[GradingCompany] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Coin] CHECK CONSTRAINT [FK_Coin_GradingCompany]
GO