CREATE PROCEDURE [dbo].[GET_IngredientsByFoodItemId]
	@FoodItemId UNIQUEIDENTIFIER
AS
SELECT Id, RecipeId, FoodItemId, Name, QuantityInGramsOrMl, DateAdded
FROM Ingredients 
WHERE FoodItemId = @FoodItemId
