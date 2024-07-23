CREATE PROCEDURE [dbo].[GET_AllRecipies]
AS
SELECT Id, Name, Description, CookingTimeInMinutes, DateAdded
FROM Recipes 
