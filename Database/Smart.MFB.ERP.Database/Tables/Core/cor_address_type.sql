CREATE TABLE [dbo].[cor_address_type]
(
	[AddressTypeId] BIGINT NOT NULL IDENTITY(1,1) Primary Key, 
    [Code] VARCHAR(10) NOT NULL , 
    [Name] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(100) NOT NULL,	
    [Active] BIT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
  
)
