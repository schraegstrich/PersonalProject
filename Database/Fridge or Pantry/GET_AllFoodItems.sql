CREATE PROCEDURE [dbo].[GET_AllFoodItems]
AS
	SELECT Id, Name, Link, QuantityInPackInGramsOrMl, QuantityInPcs, DateAdded
	FROM FoodItems
