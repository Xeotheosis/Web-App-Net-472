CREATE TABLE [dbo].[Staircases] (
    [StaircaseId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [BuildingId] INT NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    FOREIGN KEY (BuildingId) REFERENCES Buildings(BuildingId)
);
