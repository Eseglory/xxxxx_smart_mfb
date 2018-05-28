CREATE TABLE [dbo].[com_history]
(
	[CommunicationHistoryId] BIGINT NOT NULL IDENTITY(1,1)  ,
	[Code] VARCHAR(10) NOT NULL,
	[SenderId] VARCHAR(200) NOT NULL,
	[RecieverId] VARCHAR(200) NOT NULL,
	[MessageContent] VARCHAR(MAX) NOT NULL,
	[DateTimeOfMessage] DateTime NOT NULL,
	[ModeOfCommunication] VARCHAR(20) NOT NULL,
	[Active] BIT NOT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [PK_com_history] PRIMARY KEY ([Code])
)
