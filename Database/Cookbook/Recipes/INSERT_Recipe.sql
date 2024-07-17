CREATE PROCEDURE [dbo].[INSERT_Recipe]
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(250),
	@Description NVARCHAR(2000),
	@CookingTimeInMinutes INT,
	@DateAdded DATETIME 
AS
INSERT INTO Recipes
(Id,Name,Description,CookingTimeInMinutes, DateAdded)
values
(NEWID(), @Name, @Description, @CookingTimeInMinutes, SYSUTCDATETIME())