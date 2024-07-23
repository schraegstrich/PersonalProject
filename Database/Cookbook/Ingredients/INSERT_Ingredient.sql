CREATE PROCEDURE [dbo].[INSERT_Ingredient]
	@RecipeId UNIQUEIDENTIFIER,
	@FoodItemId UNIQUEIDENTIFIER,
	@Name NVARCHAR(250),
	@QuantityInGramsOrMl INT
AS
INSERT INTO Ingredients
(Id, RecipeId, FoodItemId, Name, QuantityInGramsOrMl, DateAdded)
values
(NEWID(), @RecipeId, @FoodItemId, @Name, @QuantityInGramsOrMl, SYSUTCDATETIME())