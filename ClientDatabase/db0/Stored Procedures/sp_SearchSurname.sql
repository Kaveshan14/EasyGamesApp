CREATE PROCEDURE [dbo].[sp_SearchSurname]
@Surname Varchar
	AS
	begin
	SELECT *
	FROM [dbo].[ClientTable]
	WHERE [dbo].[ClientTable].Name LIKE '%'+@Surname+'%'
	END
