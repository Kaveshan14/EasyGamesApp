CREATE PROCEDURE [dbo].[sp_SearchName]
@Name Varchar
	AS
	begin
	SELECT *
	FROM [dbo].[ClientTable]
	WHERE [dbo].[ClientTable].Name LIKE '%'+@Name+'%'
	END

