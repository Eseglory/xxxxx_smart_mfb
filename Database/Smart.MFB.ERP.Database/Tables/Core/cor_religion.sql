CREATE TABLE [dbo].[cor_religion]
(
	[ReligionId] BIGINT NOT NULL IDENTITY , 
    [Code] VARCHAR(10) NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(100) NOT NULL,
    [Active] BIT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
)
