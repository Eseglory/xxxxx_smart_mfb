CREATE TABLE [dbo].[cor_audittrail]
(
	[AuditTrailId] BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [RevisionStamp] DATETIME NOT NULL,
    [TableName] VARCHAR(200) NOT NULL, 
	[UserName] VARCHAR(200) NOT NULL, 
	[IPAddress] VARCHAR(200) NOT NULL, 
	[Actions] TINYINT NOT NULL, 
	[ActionDescription] VARCHAR(500) NULL, 
	[OldData] XML NULL,
	[NewData] XML NULL,
	[ChangedColumns] XML NULL,
    [Active] BIT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL
)
