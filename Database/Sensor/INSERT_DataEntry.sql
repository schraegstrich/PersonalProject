CREATE PROCEDURE [dbo].[INSERT_DataEntry]
	@SensorId NVARCHAR(20),
	@ProductPresent INT
AS
INSERT INTO SensorData
(DataEntryId, SensorId, ProductPresent, DateAdded)
values
(NEWID(), @SensorId, @ProductPresent, SYSUTCDATETIME())