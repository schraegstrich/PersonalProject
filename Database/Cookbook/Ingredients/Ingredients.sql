CREATE TABLE [dbo].[Ingredients]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[RecipeId] UNIQUEIDENTIFIER NOT NULL,
	[FoodItemId] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(250) NOT NULL,
	[QuantityInGramsOrMl] INT,
	[QuantityInPc] INT,
	[DateAdded] DATETIME NOT NULL,
	FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes]([Id]),
    FOREIGN KEY ([FoodItemId]) REFERENCES [dbo].[FoodItems]([Id])
)