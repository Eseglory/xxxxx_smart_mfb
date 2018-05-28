CREATE TABLE [dbo].[cor_usergroup]
(
	[UserGroupId] BIGINT NOT NULL PRIMARY KEY IDENTITY , 
    [GroupId] BIGINT NOT NULL, 
	[UserId] BIGINT NOT NULL, 
    [Active] BIT NULL, 
    [Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [AK_cor_usergroup_group] UNIQUE ([GroupId],[UserId]), 
    FOREIGN KEY ([GroupId]) REFERENCES [cor_group]([GroupId]), 
    FOREIGN KEY ([UserId]) REFERENCES [cor_user]([UserId]) 
)
