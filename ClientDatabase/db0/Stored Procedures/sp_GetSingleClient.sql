CREATE PROCEDURE [dbo].[sp_GetSingleClient]
@ID int
	AS
	begin
	SELECT *
	FROM [dbo].[TransactionTable]
	WHERE [dbo].[TransactionTable].ClientID=@ID
	END
