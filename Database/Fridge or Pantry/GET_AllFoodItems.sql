CREATE PROCEDURE [dbo].[GET_AllFoodItems]
AS
	SELECT Id, Name, Link, QuantityInPackInGramsOrMl, QuantityInPcs, Shelf, PositionOnShelf, SensorId, DateAdded
	FROM FoodItems
