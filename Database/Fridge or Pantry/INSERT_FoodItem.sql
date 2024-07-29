CREATE PROCEDURE [dbo].[INSERT_FoodItem]
	@Name NVARCHAR(250),
	@Link NVARCHAR(2500),
	@QuantityInPackInGramsOrMl INT,
	@QuantityInPcs INT,
	@Shelf INT,
	@PositionOnShelf INT,
	@SensorId NVARCHAR(20)
AS
INSERT INTO FoodItems
(Id, Name, Link, QuantityInPackInGramsOrMl, QuantityInPcs, Shelf, PositionOnShelf, SensorId, DateAdded)
values
(NEWID(), @Name, @Link, @QuantityInPackInGramsOrMl, @QuantityInPcs, @Shelf, @PositionOnShelf, @SensorId, SYSUTCDATETIME())