CREATE PROCEDURE [dbo].[sp_UpdateClientBalance]
@ID int,
@Amount int
	AS
	begin
	UPDATE [dbo].[ClientTable]
SET
ClientBalance=ClientBalance+(@Amount)
	WHERE
	ClientID=@ID
	END
