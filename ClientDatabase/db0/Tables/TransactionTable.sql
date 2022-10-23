CREATE TABLE [dbo].[TransactionTable]
(
	[TransactionID] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Amount] DECIMAL(18, 2) NOT NULL, 
    [TransactionTypeID] SMALLINT NOT NULL, 
    [ClientID] INT NOT NULL, 
    [Comment] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_Transaction_TransactionTypeTable] FOREIGN KEY ([TransactionTypeID]) REFERENCES [TransactionTypeTable]([TransactionTypeID ]), 
    CONSTRAINT [FK_Transaction_ClientTable] FOREIGN KEY ([ClientID]) REFERENCES [ClientTable]([ClientID])
)
