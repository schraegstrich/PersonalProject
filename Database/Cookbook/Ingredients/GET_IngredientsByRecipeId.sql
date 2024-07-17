CREATE PROCEDURE [dbo].[GET_IngredientsByRecipeId]
	@RecipeId UNIQUEIDENTIFIER
AS
SELECT Id, RecipeId, FoodItemId, Name, QuantityInGramsOrMl, DateAdded
FROM Ingredients 
WHERE RecipeId = @RecipeId
