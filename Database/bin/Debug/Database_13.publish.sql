﻿/*
Deployment script for PersonalProjectDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "PersonalProjectDB"
:setvar DefaultFilePrefix "PersonalProjectDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"

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
PRINT N'Altering Table [dbo].[SensorData]...';


GO
ALTER TABLE [dbo].[SensorData] ALTER COLUMN [ProductPresent] INT NOT NULL;


GO
PRINT N'Altering Procedure [dbo].[INSERT_DataEntry]...';


GO
ALTER PROCEDURE [dbo].[INSERT_DataEntry]
	@SensorId INT,
	@Shelf INT,
	@PositionOnShelf INT,
	@FoodItemId UNIQUEIDENTIFIER,
	@ProductPresent INT
AS
INSERT INTO SensorData
(DataEntryId, SensorId, Shelf, PositionOnShelf, FoodItemId, ProductPresent, DateAdded)
values
(NEWID(), @SensorId, @Shelf, @PositionOnShelf, @FoodItemId, @ProductPresent, SYSUTCDATETIME())
GO
PRINT N'Update complete.';


GO