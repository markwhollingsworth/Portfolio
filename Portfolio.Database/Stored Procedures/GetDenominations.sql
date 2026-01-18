-- =============================================
-- Author:      Mark Hollingsworth
-- Create Date: 1/21/23
-- Description: Gets coin denominations
-- =============================================
CREATE PROCEDURE [dbo].[GetDenominations]
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    SELECT Id,
	       Description
	FROM dbo.Denomination;
END