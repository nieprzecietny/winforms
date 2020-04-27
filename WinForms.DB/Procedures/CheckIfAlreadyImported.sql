CREATE PROCEDURE [dbo].[CheckIfAlreadyImported]
	@filename nvarchar(255) = 0,
	@importDate date
AS
BEGIN 
IF EXISTS (SELECT 1 FROM [dbo].[FileLoadLog] WHERE [FileName] = @filename and [DateLoad] = @importDate)  
	SELECT 1 as Imported
ELSE 
	SELECT 0 as Imported
END