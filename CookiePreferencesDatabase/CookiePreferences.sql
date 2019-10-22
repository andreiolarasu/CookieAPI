CREATE TABLE [dbo].[CookiePreferences]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Batch] NVARCHAR(50) NOT NULL, 
    [Created] DATETIME NOT NULL, 
    [TimestampJoined] DATETIME NOT NULL, 
    [TimestampYes] DATETIME NULL, 
    [TimeStampNo] DATETIME NULL, 
    [TimeStampRead] DATETIME NULL, 
    [TimeStampAgreeAll] DATETIME NULL, 
    [TimeStampDisagreeAll] DATETIME NULL, 
    [TimeStampCustom] DATETIME NULL
)
