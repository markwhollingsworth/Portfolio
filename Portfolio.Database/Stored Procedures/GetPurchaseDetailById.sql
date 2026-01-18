-- =============================================
-- Author:      Mark Hollingsworth
-- Create Date: 1/31/23
-- Description: Gets the purchase details.
-- =============================================
CREATE PROCEDURE [dbo].[GetPurchaseDetailById]
(
    @Id INT
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT [Id], 
           [Subtotal], 
           [Shipping], 
           [Tax], 
           [Total], 
           [Date], 
           [SellerName], 
           [SellerAddress], 
           [Quantity], 
           [CoinId]
	FROM [dbo].[PurchaseDetail] 
	WHERE Id = @Id;
END
GO