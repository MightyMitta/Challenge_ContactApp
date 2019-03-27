CREATE TABLE [dbo].[contact]
(
	[contact_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [address_id] INT NOT NULL, 
    [firstname] VARCHAR(100) NOT NULL, 
    [middlename] VARCHAR(100) NULL, 
    [lastname] VARCHAR(100) NULL, 
    [phonenumber] VARCHAR(100) NULL, 
    [email] VARCHAR(100) NULL, 
    CONSTRAINT [FK_contact_address] FOREIGN KEY (address_id) REFERENCES address(address_id)
)
