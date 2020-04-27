CREATE PROCEDURE [dbo].[ImportTransactions]
	@filename nvarchar(255),
	@importDate date,
	@data TransactionRow READONLY
AS
BEGIN 
IF NOT EXISTS (SELECT 1 FROM [dbo].[FileLoadLog] WITH (NOLOCK) WHERE [FileName] = @filename and [DateLoad] = @importDate)  
DECLARE @fileId int =0;
INSERT INTO FileLoadLog (FileName ,DateLoad) values (@filename, @importDate)
SELECT @fileId = SCOPE_IDENTITY();

	INSERT INTO [Transaction](FileId,RawData,DATAOBCIAZENIARACHUNKU,KWOTA,RACHUNEKKLIENTAADRESATA)
	SELECT @fileId ,RawData ,DATAOBCIAZENIARACHUNKU,KWOTA,RACHUNEKKLIENTAADRESATA
	FROM @data
END