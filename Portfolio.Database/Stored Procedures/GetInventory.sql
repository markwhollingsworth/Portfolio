-- =============================================
-- Author:      Mark Hollingsworth
-- Create Date: 1-16-2023
-- Updates: 11-9-2024 - fix broken joins
-- Description: Gets coin inventory
-- =============================================
CREATE PROCEDURE [dbo].[GetInventory]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT c.Id
	      ,c.Description 
		  ,c.ListPrice
		  ,pd.Quantity
		  --,MintId = m.Id
		  --,DenominationId = d.Id
	FROM dbo.Coin c
	INNER JOIN dbo.PurchaseDetail pd
	  ON c.Id = pd.CoinId
	--INNER JOIN dbo.Denomination d
	  --ON c.DenominationId = d.Id
	--INNER JOIN dbo.Mint m 
	  --ON c.MintId = m.Id;
END
GO