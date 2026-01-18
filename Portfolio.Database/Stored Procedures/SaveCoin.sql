-- =============================================
-- Author:      Mark Hollingsworth
-- Create Date: 1/24/23
-- Description: Saves a coin 
-- =============================================
CREATE PROCEDURE [dbo].[SaveCoin]
(
    @Year VARCHAR(250),
    @ListPrice DECIMAL(9,2),
    @Description VARCHAR(1000),
    @Quantity INT,
    @Subtotal DECIMAL(9,2),
    @Shipping DECIMAL(9,2),
    @Tax DECIMAL(9,2),
    @Total DECIMAL(9,2),
    @Date DATETIME,
    @SellerName VARCHAR(250),
    @SellerAddress VARCHAR(500),
    @MintId INT = NULL,
    @DenominationId INT = NULL,
    @GradingCompanyId INT = NULL,
    @Grade VARCHAR(50) = NULL
)
AS
BEGIN


    INSERT INTO dbo.Coin([Year], 
                         [ListPrice], 
                         [Description], 
                         [Quantity], 
                         [DenominationId], 
                         [MintId],
                         [GradingCompanyId],
                         [Grade])
	VALUES(@Year, 
           @ListPrice, 
           @Description, 
           @Quantity, 
           @DenominationId, 
           @MintId,
           @GradingCompanyId,
           @Grade);

    DECLARE @NewCoinId INT = SCOPE_IDENTITY()

    INSERT INTO dbo.PurchaseDetail([Subtotal],
                                   [Shipping],
	                               [Tax],
	                               [Total],
	                               [Date],
	                               [SellerName],
	                               [SellerAddress],
	                               [Quantity],
	                               [CoinId])
    VALUES(@Subtotal,
           @Shipping,
           @Tax,
           @Total,
           @Date,
           @SellerName,
           @SellerAddress,
           @Quantity,
           @NewCoinId)

    DECLARE @NewPurchaseDetailId INT = SCOPE_IDENTITY()

    UPDATE dbo.Coin
    SET PurchaseDetailId = @NewPurchaseDetailId
    WHERE Id = @NewCoinId
END