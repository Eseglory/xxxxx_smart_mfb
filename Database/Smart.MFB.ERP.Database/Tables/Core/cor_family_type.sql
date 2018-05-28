CREATE TABLE [dbo].[cor_family_type]
(
	[FamilyTypeId] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(100) NULL,	
    [Active] BIT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL,   
)
