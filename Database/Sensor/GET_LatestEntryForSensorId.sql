CREATE PROCEDURE [dbo].[GET_LatestEntryForSensorId]
    @SensorId NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1
        [DataEntryId],
        [SensorId],
        [ProductPresent],
        [DateAdded]
    FROM
        [dbo].[SensorData]
    WHERE
        [SensorId] = @SensorId
    ORDER BY
        [DateAdded] DESC;
END

