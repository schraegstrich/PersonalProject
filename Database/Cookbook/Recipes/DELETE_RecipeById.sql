﻿CREATE PROCEDURE [dbo].[DELETE_RecipeById]
	@Id UNIQUEIDENTIFIER
AS
	DELETE FROM Recipes
	WHERE Id = @Id