CREATE TABLE ErrorLogs (
    LogId INT PRIMARY KEY IDENTITY,
    UserId INT NULL,
    Username NVARCHAR(50) NULL,
    ErrorMessage NVARCHAR(MAX),
    StackTrace NVARCHAR(MAX),
    Timestamp DATETIME,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
