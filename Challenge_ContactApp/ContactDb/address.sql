CREATE TABLE [dbo].[address]
(
	[address_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [street] VARCHAR(100) NULL, 
    [city] VARCHAR(100) NULL, 
    [postalcode] VARCHAR(100) NULL, 
    [country] VARCHAR(100) NULL, 
    [housenumber] INT NULL 
)
