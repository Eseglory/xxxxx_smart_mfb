CREATE TABLE [dbo].[cor_theme]
(
	[ThemeId] BIGINT NOT NULL IDENTITY(1,1), 
    [Code] VARCHAR(20) NOT NULL , 
    [Active] BIT NULL, 
	[Deleted] BIT NULL, 
    [CreatedBy] VARCHAR(50) NULL, 
    [CreatedOn] DATETIME NULL, 
    [UpdatedBy] VARCHAR(50) NULL, 
    [UpdatedOn] DATETIME NULL, 
    [RowVersion] TIMESTAMP NOT NULL, 
)
