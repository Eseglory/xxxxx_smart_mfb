CREATE TABLE [dbo].[cor_group]
(
	[GroupId] BIGINT NOT NULL IDENTITY(1,1), 
    CONSTRAINT [PK_cor_group] PRIMARY KEY ([GroupId]), 
    [Name] VARCHAR(100) NOT NULL, 
	[Description] VARCHAR(500) NULL, 
    [Active] BIT NULL, 
    [Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [AK_cor_group_name] UNIQUE ([Name]) 
)
