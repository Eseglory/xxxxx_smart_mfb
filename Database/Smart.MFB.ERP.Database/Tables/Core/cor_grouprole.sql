CREATE TABLE [dbo].[cor_grouprole]
(
	[GroupRoleId] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY , 
    [GroupId] BIGINT NOT NULL , 
	[RoleId] BIGINT NOT NULL, 
    [Active] BIT NULL, 
    [Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
    UNIQUE ([GroupId],[RoleId]), 
    FOREIGN KEY ([GroupId]) REFERENCES [cor_group]([GroupId]), 
    FOREIGN KEY ([RoleId]) REFERENCES [cor_role]([RoleId]) 
)
