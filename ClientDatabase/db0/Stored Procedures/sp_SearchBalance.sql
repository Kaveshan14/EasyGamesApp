CREATE PROCEDURE [dbo].[sp_SearchBalance]
@Balance int
	AS
	begin
	SELECT *
	FROM [dbo].[ClientTable]
	WHERE [dbo].[ClientTable].ClientBalance =@Balance
	END
