CREATE PROCEDURE [dbo].[UPDATE_FoodItemById]
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(250),
	@Link NVARCHAR(2500),
	@QuantityInPackInGramsOrMl INT,
	@QuantityInPcs INT,
	@Shelf INT,
	@PositionOnShelf INT,
	@SensorId NVARCHAR(20)
AS
UPDATE FoodItems
SET  Name = @Name, Link = @Link, QuantityInPackInGramsOrMl = @QuantityInPackInGramsOrMl, QuantityInPcs = @QuantityInPcs, Shelf = @Shelf, PositionOnShelf = @PositionOnShelf, SensorId = @SensorId, DateAdded = SYSUTCDATETIME() 
WHERE Id = @Id
