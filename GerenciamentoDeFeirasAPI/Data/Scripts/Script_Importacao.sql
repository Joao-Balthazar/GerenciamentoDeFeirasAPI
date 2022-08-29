SET NOCOUNT ON;

-- import the file
BULK INSERT dbo.Feiras
FROM 'Caminho do Arquivo'
WITH ( FIRSTROW = 2
	 , FIELDTERMINATOR = ','
	 , ROWTERMINATOR = '\n'
	 )
GO

