CREATE PROCEDURE [dbo].[UPDATE_RecipeById]
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(250),
	@Description NVARCHAR(2000),
	@CookingTimeInMinutes INT
AS
UPDATE Recipes
SET Name = @Name,Description = @Description, CookingTimeInMinutes = @CookingTimeInMinutes, DateAdded = SYSUTCDATETIME()
WHERE Id = @Id