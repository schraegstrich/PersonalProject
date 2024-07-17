CREATE PROCEDURE [dbo].[INSERT_FoodItem]
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(250),
	@Link NVARCHAR(2500),
	@QuantityInPackInGramsOrMl INT,
	@QuantityInPcs INT,
	@DateAdded DATETIME 
AS
INSERT INTO FoodItems
(Id, Name, Link, QuantityInPackInGramsOrMl, QuantityInPcs, DateAdded)
values
(NEWID(), @Name, @Link, @QuantityInPackInGramsOrMl, @QuantityInPcs, SYSUTCDATETIME())