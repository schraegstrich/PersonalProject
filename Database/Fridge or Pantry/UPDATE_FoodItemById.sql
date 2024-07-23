CREATE PROCEDURE [dbo].[UPDATE_FoodItemById]
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(250),
	@Link NVARCHAR(2500),
	@QuantityInPackInGramsOrMl INT,
	@QuantityInPcs INT
AS
UPDATE FoodItems
SET  Name = @Name, Link = @Link, QuantityInPackInGramsOrMl = @QuantityInPackInGramsOrMl, QuantityInPcs = @QuantityInPcs, DateAdded = SYSUTCDATETIME() 
WHERE Id = @Id
