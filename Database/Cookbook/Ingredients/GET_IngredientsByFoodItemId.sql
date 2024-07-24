CREATE PROCEDURE [dbo].[GET_IngredientsByFoodItemId]
	@FoodItemId UNIQUEIDENTIFIER
AS
SELECT Id, RecipeId, FoodItemId, Name, QuantityInGramsOrMl, QuantityInPcs, DateAdded
FROM Ingredients 
WHERE FoodItemId = @FoodItemId
