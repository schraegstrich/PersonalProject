CREATE PROCEDURE [dbo].[GET_IngredientById]
	@Id UNIQUEIDENTIFIER
AS
SELECT Id, RecipeId, FoodItemId, Name, QuantityInGramsOrMl, DateAdded
FROM Ingredients 
WHERE Id = @Id
