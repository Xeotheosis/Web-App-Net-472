CREATE TABLE [dbo].[UserAssociations] (
    [UserId] INT NOT NULL,
    [AssociationId] INT NOT NULL,
    PRIMARY KEY ([UserId], [AssociationId]),
    FOREIGN KEY ([UserId]) REFERENCES Users([UserId]),
    FOREIGN KEY ([AssociationId]) REFERENCES Associations([AssociationId])
);
