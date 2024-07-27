CREATE PROCEDURE [dbo].[GET_LatestEntryForFoodItemId]
    @FoodItemId UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1
        [DataEntryId],
        [SensorId],
        [Shelf],
        [PositionOnShelf],
        [FoodItemId],
        [ProductPresent],
        [DateAdded]
    FROM
        [dbo].[SensorData]
    WHERE
        [FoodItemId] = @FoodItemId
    ORDER BY
        [DateAdded] DESC;
END

