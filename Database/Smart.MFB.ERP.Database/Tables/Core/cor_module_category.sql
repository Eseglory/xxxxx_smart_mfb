CREATE TABLE [dbo].[cor_module_category]
(
	[ModuleCategoryId] BIGINT NOT NULL IDENTITY PRIMARY KEY, 
	[Code] VARCHAR(10) NOT NULL , 
    [Name] VARCHAR(100) NOT NULL, 
    [Alias] VARCHAR(100) NOT NULL, 
	[Description] VARCHAR(500) NULL, 
    [Active] BIT NULL, 
    [Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [AK_cor_module_category_code] UNIQUE ([Code]), 
    CONSTRAINT [AK_cor_module_category_name] UNIQUE ([Name]),
)
