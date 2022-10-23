﻿/*
Deployment script for ClientDBNew

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ClientDBNew"
:setvar DefaultFilePrefix "ClientDBNew"
:setvar DefaultDataPath "C:\Users\Proline\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\Proline\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering Procedure [dbo].[sp_SearchBalance]...';


GO
ALTER PROCEDURE [dbo].[sp_SearchBalance]
@Balance int
	AS
	begin
	SELECT *
	FROM [dbo].[ClientTable]
	WHERE [dbo].[ClientTable].ClientBalance LIKE '%'+@Balance+'%'
	END
GO
PRINT N'Altering Procedure [dbo].[sp_SearchName]...';


GO
ALTER PROCEDURE [dbo].[sp_SearchName]
@Name Varchar
	AS
	begin
	SELECT *
	FROM [dbo].[ClientTable]
	WHERE [dbo].[ClientTable].Name LIKE '%'+@Name+'%'
	END
GO
PRINT N'Altering Procedure [dbo].[sp_SearchSurname]...';


GO
ALTER PROCEDURE [dbo].[sp_SearchSurname]
@Surname Varchar
	AS
	begin
	SELECT *
	FROM [dbo].[ClientTable]
	WHERE [dbo].[ClientTable].Name LIKE '%'+@Surname+'%'
	END
GO
PRINT N'Update complete.';


GO
