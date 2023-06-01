﻿/*
Deployment script for SemesterProjectDb

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SemesterProjectDb"
:setvar DefaultFilePrefix "SemesterProjectDb"
:setvar DefaultDataPath "C:\Users\lenovo\AppData\Local\Microsoft\VisualStudio\SSDT"
:setvar DefaultLogPath "C:\Users\lenovo\AppData\Local\Microsoft\VisualStudio\SSDT"

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
PRINT N'Rename refactoring operation with key a004350d-1395-4f87-ac97-16faf152a376 is skipped, element [dbo].[Users].[Id] (SqlSimpleColumn) will not be renamed to userId';


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [userId]     INT           NOT NULL,
    [userName]   VARCHAR (100) NULL,
    [userEmail`] VARCHAR (255) NULL,
    [userPass]   NCHAR (20)    NULL,
    PRIMARY KEY CLUSTERED ([userId] ASC)
);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'a004350d-1395-4f87-ac97-16faf152a376')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('a004350d-1395-4f87-ac97-16faf152a376')

GO

GO
PRINT N'Update complete.';


GO
