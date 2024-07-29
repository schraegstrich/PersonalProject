CREATE TABLE [dbo].[FoodItems]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(250) NOT NULL,
	[Link] NVARCHAR(2500),
	[QuantityInPackInGramsOrMl] INT,
	[QuantityInPcs] INT,
	[Shelf] INT NOT NULL,
	[PositionOnShelf] INT NOT NULL,
	[SensorId] NVARCHAR(20) NOT NULL,
	[DateAdded] DATETIME NOT NULL
)