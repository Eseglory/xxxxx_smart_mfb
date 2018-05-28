CREATE TABLE [dbo].[cor_state]
(
	[StateId] BIGINT NOT NULL IDENTITY , 
    [Code] VARCHAR(10) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(100) NOT NULL,
	[CountryCode] VARCHAR(10) NOT NULL , 
    [Active] BIT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
    FOREIGN KEY ([CountryCode]) REFERENCES [cor_country]([Code]) 
    
)
