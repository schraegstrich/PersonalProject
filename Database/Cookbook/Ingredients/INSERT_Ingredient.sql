CREATE PROCEDURE [dbo].[INSERT_Ingredient]
	@Id UNIQUEIDENTIFIER,
	@RecipeId UNIQUEIDENTIFIER,
	@FoodItemId UNIQUEIDENTIFIER,
	@Name NVARCHAR(250),
	@QuantityInGramsOrMl INT,
	@DateAdded DATETIME 
AS
INSERT INTO Ingredients
(Id, RecipeId, FoodItemId, Name, QuantityInGramsOrMl, DateAdded)
values
(NEWID(), @RecipeId, @FoodItemId, @Name, @QuantityInGramsOrMl, SYSUTCDATETIME())