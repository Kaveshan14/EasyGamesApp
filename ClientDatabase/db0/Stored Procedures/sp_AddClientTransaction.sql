CREATE PROCEDURE [dbo].[sp_AddClientTransaction]
@ID int,
@TransactionType int,
@Amount int
	AS
	begin
	INSERT INTO [dbo].[TransactionTable]
	(
	
	Amount,
	TransactionTypeID,
	ClientID
	)
	VALUES (

	@Amount,
	@TransactionType,
	@ID
	)
	END

	