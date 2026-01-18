-- =============================================
-- Author:      Mark Hollingsworth
-- Create Date: 1/26/23
-- Description: Deletes a specific coin.
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCoin]
(
    @CoinId INT
)
AS
BEGIN
    DELETE 
	FROM dbo.Coin
	WHERE Id = @CoinId;
END
GO