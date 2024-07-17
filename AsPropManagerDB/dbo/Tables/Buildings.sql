CREATE TABLE [dbo].[Buildings] (
    [BuildingId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [AssociationId] INT NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    FOREIGN KEY (AssociationId) REFERENCES Associations(AssociationId)
);
