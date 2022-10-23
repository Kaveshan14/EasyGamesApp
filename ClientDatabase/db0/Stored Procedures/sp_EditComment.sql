CREATE PROCEDURE [dbo].[sp_EditComment]
@ID int,
@ClientID int,
@Comment varchar(100)
	AS
	begin
	UPDATE [dbo].[TransactionTable]
SET
Comment=@Comment
	WHERE
	ClientID=@ClientID AND TransactionID=@ID
	END