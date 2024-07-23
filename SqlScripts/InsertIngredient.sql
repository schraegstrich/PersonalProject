DECLARE @Id UNIQUEIDENTIFIER = NEWID();
DECLARE @RecipeId UNIQUEIDENTIFIER = '060B654C-731A-4A21-97BF-F590C2D11CA8';
DECLARE @FoodItemId UNIQUEIDENTIFIER = '3CC3819A-66EC-4008-8E22-BBAF0E965969';
DECLARE @Name NVARCHAR(250) = 'Eggplant';
DECLARE @QuantityInPackInGramsOrMl INT = 1;
DECLARE @DateAdded DATETIME = SYSUTCDATETIME();

EXEC [dbo].[INSERT_Ingredient]
    @Id,
    @RecipeId,
    @FoodItemId,
	@Name,
    @QuantityInPackInGramsOrMl,
	@DateAdded