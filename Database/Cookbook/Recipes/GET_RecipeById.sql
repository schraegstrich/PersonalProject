CREATE PROCEDURE [dbo].[GET_RecipeById]
	@Id UNIQUEIDENTIFIER
AS
	SELECT Id, Name, Description, CookingTimeInMinutes, DateAdded
	FROM Recipes
	WHERE Id = @Id

