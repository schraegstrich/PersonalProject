CREATE PROCEDURE [dbo].[INSERT_Ingredient]
	@RecipeId UNIQUEIDENTIFIER,
	@FoodItemId UNIQUEIDENTIFIER,
	@Name NVARCHAR(250),
	@QuantityInGramsOrMl INT,
	@QuantityInPcs INT
AS
INSERT INTO Ingredients
(Id, RecipeId, FoodItemId, Name, QuantityInGramsOrMl,QuantityInPcs, DateAdded)
values
(NEWID(), @RecipeId, @FoodItemId, @Name, @QuantityInGramsOrMl, @QuantityInPcs, SYSUTCDATETIME())