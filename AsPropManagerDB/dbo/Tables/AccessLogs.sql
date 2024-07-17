CREATE TABLE AccessLogs (
    LogId INT PRIMARY KEY IDENTITY,
    UserId INT,
    Username NVARCHAR(50),
    Action NVARCHAR(100),
    Timestamp DATETIME,
    Details NVARCHAR(MAX),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

