-- =============================================  
-- Author:      Mark Hollingsworth
-- Create date: 2/7/2022
-- Description: Gets all coins, or by year, if specified.
-- =============================================  
CREATE PROCEDURE [dbo].[GetCoins]
(
	@Year VARCHAR(100) = NULL
)
AS
BEGIN
	IF (@Year IS NULL)
	BEGIN
		SELECT c.Id
		      ,c.[Year]
	          ,c.ListPrice
		      ,DenominationId = d.Id
		      ,MintId = m.Id
			  ,c.Description
		FROM dbo.Coin c
		LEFT JOIN dbo.Denomination d
	      ON d.Id = c.DenominationId
	    LEFT JOIN dbo.Mint m
	      ON c.MintId = m.Id
	END
	ELSE
		SELECT c.Id
			  ,c.[Year]
		      ,c.ListPrice
			  ,DenominationId = d.Id
			  ,MintId = m.Id
			  ,c.Description
		FROM dbo.Coin c
		LEFT JOIN dbo.Denomination d
		  ON d.Id = c.DenominationId
		LEFT JOIN dbo.Mint m
		  ON c.MintId = m.Id
		WHERE [Year] = @Year;
END;