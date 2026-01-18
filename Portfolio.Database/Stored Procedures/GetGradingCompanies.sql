CREATE PROCEDURE [dbo].[GetGradingCompanies]
AS
BEGIN
	SELECT [Id],
	       [Description],
		   [Abbreviation]
	FROM [dbo].[GradingCompany]
END

