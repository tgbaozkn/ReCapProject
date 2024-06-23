CREATE TABLE [dbo].[Cars]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [BrandId] INT NOT NULL, 
    [ColorId] INT NOT NULL, 
    [ModelYear] NVARCHAR(50) NOT NULL, 
    [DailyPrice] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(250) NOT NULL
	

)
