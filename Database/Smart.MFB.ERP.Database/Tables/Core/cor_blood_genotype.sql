CREATE TABLE [dbo].[cor_blood_genotype]
(
	[BloodGenotypeId] BIGINT NOT NULL IDENTITY(1,1), 
    [Name] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(100) NOT NULL,	
    [Active] BIT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
    CONSTRAINT [PK_cor_blood_genotype] PRIMARY KEY ([BloodGenotypeId]), 
   
  
)
