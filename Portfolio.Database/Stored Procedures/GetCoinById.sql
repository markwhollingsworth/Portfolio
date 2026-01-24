-- =============================================
-- Author:      Mark Hollingsworth
-- Create Date: 1/31/23
-- Description: Gets a coin for a given Id.
-- =============================================
CREATE PROCEDURE [dbo].[GetCoinById]
(
    @Id INT
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT c.[Id], 
	       c.[Year], 
		   c.[ListPrice], 
           c.[Description],
		   c.[Quantity],
           c.[IsForSale],
           c.[PurchaseDetailId],
           c.[MintId]
	FROM dbo.Coin c
	WHERE c.Id = @Id;
END
GO