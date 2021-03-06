﻿CREATE TABLE [dbo].[com_channel_setup]
(
	[ChannelId] BIGINT NOT NULL IDENTITY(1,1)  ,
	[Code] VARCHAR(10) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(200) NOT NULL,
	[Default] BIT NOT NULL, 
	[Active] BIT NOT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
)
