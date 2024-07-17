DECLARE @Id UNIQUEIDENTIFIER = NEWID();
DECLARE @Name NVARCHAR(250) = 'Caponatta eggplant pan with Kalamata olives';
DECLARE @Description NVARCHAR(2000) = '';
DECLARE @CookingTimeInMinutes INT = 40;
DECLARE @DateAdded DATETIME = SYSUTCDATETIME();

EXEC [dbo].[INSERT_Recipe]
    @Id,
    @Name,
    @Description,
    @CookingTimeInMinutes,
    @DateAdded;