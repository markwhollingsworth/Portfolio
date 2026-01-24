-- =============================================
-- Author:      Mark Hollingsworth
-- Create Date: 3/9/25
-- Description: Gets a mint for a given Id.
-- =============================================
CREATE PROCEDURE [dbo].[GetMintById]
(
    @Id INT
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT m.Id,
	       m.Abbreviation,
		   m.Name, 
		   m.IsActive
	FROM dbo.Mint m
	WHERE m.Id = @Id;
END
GO