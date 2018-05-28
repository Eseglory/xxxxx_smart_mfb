CREATE TABLE [dbo].[cor_menurole]
(
	[MenuRoleId] BIGINT NOT NULL PRIMARY KEY IDENTITY , 
    [MenuId] BIGINT NOT NULL, 
	[RoleId] BIGINT NOT NULL, 
    [Active] BIT NULL, 
    [Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [AK_cor_menurole_role] UNIQUE ([MenuId],[RoleId]), 
    FOREIGN KEY ([MenuId]) REFERENCES [cor_menu]([MenuId]), 
    FOREIGN KEY ([RoleId]) REFERENCES [cor_role]([RoleId]) 
)
