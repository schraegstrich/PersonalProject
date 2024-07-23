CREATE PROCEDURE [dbo].[UPDATE_IngredientById]
	@Id UNIQUEIDENTIFIER,
	@RecipeId UNIQUEIDENTIFIER,
	@FoodItemId UNIQUEIDENTIFIER,
	@Name NVARCHAR(250),
	@QuantityInGramsOrMl INT,
AS
UPDATE Ingredients
SET RecipeId = @RecipeId, FoodItemId = @FoodItemId, Name = @Name, QuantityInGramsOrMl = @QuantityInGramsOrMl, DateAdded = SYSUTCDATETIME()
WHERE Id = @Id