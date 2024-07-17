CREATE TABLE [dbo].[Associations]
(
	 [AssociationId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
	[AdminUsernames] nvarchar(max)
)
