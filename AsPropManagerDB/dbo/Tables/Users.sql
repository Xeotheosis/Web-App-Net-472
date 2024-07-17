CREATE TABLE [dbo].[Users]
(
    [UserId] INT NOT NULL PRIMARY KEY IDENTITY,
    [UserName] NVARCHAR(100) NOT NULL,
    [PasswordHash] NVARCHAR(256) NOT NULL,
    [Role] NVARCHAR(50) NOT NULL, 
    [AdministeredAssociations] NVARCHAR(MAX) NULL
);