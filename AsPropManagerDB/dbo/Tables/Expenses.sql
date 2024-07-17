CREATE TABLE [dbo].[Expenses] ( [ExpenseId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [AssociationId] INT NOT NULL,
    [StaircaseId] INT NULL,
    [Description] NVARCHAR(200) NOT NULL,
    [Amount] FLOAT NOT NULL,
    [ExpenseType] NVARCHAR(50) NOT NULL,
    FOREIGN KEY (AssociationId) REFERENCES Associations(AssociationId),
    FOREIGN KEY (StaircaseId) REFERENCES Staircases(StaircaseId)
);
