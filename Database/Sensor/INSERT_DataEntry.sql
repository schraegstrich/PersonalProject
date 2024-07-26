CREATE PROCEDURE [dbo].[INSERT_DataEntry]
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