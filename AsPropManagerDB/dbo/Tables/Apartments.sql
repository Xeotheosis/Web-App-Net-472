CREATE TABLE [dbo].[Apartments] (
    [ApartmentId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [StaircaseId] INT NOT NULL,
    [Number] NVARCHAR(10) NOT NULL,
    [HasGasCentralHeating] BIT NOT NULL,
    [SurfaceArea] FLOAT NOT NULL,
    [PeopleCount] INT NOT NULL,
    [ColdWaterMeterReading] FLOAT NULL,
    [HotWaterMeterReading] FLOAT NULL,
    FOREIGN KEY (StaircaseId) REFERENCES Staircases(StaircaseId)
);
