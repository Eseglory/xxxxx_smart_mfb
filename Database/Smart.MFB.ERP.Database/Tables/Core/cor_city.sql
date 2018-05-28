CREATE TABLE [dbo].[cor_city]
(
	[CityId] BIGINT NOT NULL IDENTITY(1,1), 
	[Code] VARCHAR(10) NOT NULL PRIMARY KEY, 
	[Name] VARCHAR(100) NOT NULL,
	[StateId] BigInt NOT NULL , 
	[StateCode] VARCHAR(50) NOT NULL , 
	[Active] BIT NULL, 
	[Deleted] BIT NULL, 
	[CreatedBy] VARCHAR(50) NULL, 
	[CreatedOn] DATETIME NULL, 
	[UpdatedBy] VARCHAR(50) NULL, 
	[UpdatedOn] DATETIME NULL, 
	[RowVersion] TIMESTAMP NOT NULL, 

)
