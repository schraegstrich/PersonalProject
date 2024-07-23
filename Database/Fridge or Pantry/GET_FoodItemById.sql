CREATE PROCEDURE [dbo].[GET_FoodItemById]
	@Id UNIQUEIDENTIFIER
AS
	SELECT Id, Name, Link, QuantityInPackInGramsOrMl, QuantityInPcs, DateAdded
	FROM FoodItems
	WHERE Id = @Id
