CREATE TABLE [dbo].[com_email_setup]
(
	[EmailSetupId] BIGINT NOT NULL IDENTITY(1,1),
	[Code] VARCHAR(10) NOT NULL PRIMARY KEY,
	[ModuleCode] VARCHAR(10) NOT NULL,
	[MailHost] VARCHAR(200) NOT NULL,
	[MailPort] VARCHAR(20) NOT NULL,
	[SenderEmail] VARCHAR(200) NOT NULL,
	[SenderUsername] VARCHAR(200) NOT NULL,
	[SenderPassword] VARCHAR(200) NOT NULL,
    [Default] BIT NULL, 
	[Active] BIT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 

)
