CREATE PROCEDURE [dbo].[INSERT_Recipe]
	@Name NVARCHAR(250),
	@Description NVARCHAR(2000),
	@CookingTimeInMinutes INT
AS
INSERT INTO Recipes
(Id,Name,Description,CookingTimeInMinutes, DateAdded)
values
(NEWID(), @Name, @Description, @CookingTimeInMinutes, SYSUTCDATETIME())