CREATE PROCEDURE [dbo].[sp_GetAllClients]
    AS
	begin
	SELECT *
	FROM [dbo].[ClientTable]
	end