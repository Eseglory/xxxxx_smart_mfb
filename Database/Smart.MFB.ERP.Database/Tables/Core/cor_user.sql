CREATE TABLE [dbo].[cor_user]
(
	[UserId] BIGINT NOT NULL IDENTITY PRIMARY KEY , 
	[LoginID] VARCHAR(250) NOT NULL, 
    [FirstName] VARCHAR(100) NOT NULL, 
	[LastName] VARCHAR(100) NOT NULL, 
    [Email] VARCHAR(250) NOT NULL, 
	[Mobile] VARCHAR(50) NOT NULL,	
	[EntityScope] TinyInt NOT NULL,
	[ScopeCode] VARCHAR(20) NOT NULL,
	[GroupId] BIGINT NOT NULL,
	[EmployeeCode] VARCHAR(6) NOT NULL,
	[LastLoginDate] DateTime NULL,
	[IsLock]BIT NULL, 
    [Active] BIT NULL, 
    [Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [AK_cor_user_loginid] UNIQUE ([LoginID]) 
)
