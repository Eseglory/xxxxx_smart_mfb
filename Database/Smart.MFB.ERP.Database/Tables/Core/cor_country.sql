CREATE TABLE [dbo].[cor_country]
(
	[CountryId] BIGINT NOT NULL IDENTITY(1,1), 
    [Code] VARCHAR(10) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(100) NOT NULL, 
	[ShortCode] VARCHAR(10) NULL,
    [Active] BIT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
)
