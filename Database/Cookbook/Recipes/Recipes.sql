CREATE TABLE [dbo].[Recipes]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(250) NOT NULL,
	[Description] NVARCHAR(2000),
	[CookingTimeInMinutes] INT NOT NULL,
	[DateAdded] DATETIME NOT NULL
)