CREATE TABLE [dbo].[com_sms_setup]
(
	[SMSSetupId] BIGINT NOT NULL IDENTITY(1,1),
	[Code] VARCHAR(10) NOT NULL PRIMARY KEY,
	[AccountType] TinyInt NOT NULL,
	[Name] VARCHAR(200) NOT NULL,
	[UrlParameter] VARCHAR(200) NULL,
	[Username] VARCHAR(200) NOT NULL,
	[Password] VARCHAR(200) NOT NULL,
	[Source] VARCHAR(200) NOT NULL,
    [Active] BIT NULL, 
	[Default] BIT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
)
