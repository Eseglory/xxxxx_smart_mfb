CREATE TABLE [dbo].[cor_role]
(
	[RoleId] BIGINT NOT NULL PRIMARY KEY IDENTITY , 
    [Name] VARCHAR(100) NOT NULL, 
	[ModuleId] BIGINT NOT NULL,
	[Description] VARCHAR(500) NULL, 
    [Active] BIT NULL, 
    [Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [AK_cor_role_name] UNIQUE ([Name],[ModuleId]), 
    FOREIGN KEY ([ModuleId]) REFERENCES [cor_module]([ModuleId]), 
)
