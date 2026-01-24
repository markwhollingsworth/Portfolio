-- =============================================
-- Author:      Mark Hollingsworth
-- Create Date: 1/21/2023
-- Description: Gets a list of mint marks
-- =============================================
CREATE PROCEDURE [dbo].[GetMints]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT Id,
	       Abbreviation,
		   Name, 
		   IsActive
	FROM dbo.Mint
END
