USE [crud];
GO

IF SCHEMA_ID(N'Note') IS NULL
BEGIN
    EXEC(N'CREATE SCHEMA Note');
END
GO

-- PreProcessedDate is stamped by the pre-decorator, PostProcessedDate by the post-decorator,
-- so each row shows whether both Signalynx decorators ran and in which order.
IF OBJECT_ID(N'Note.Note', N'U') IS NULL
BEGIN
    CREATE TABLE Note.Note
    (
        NoteId            INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Note_Note PRIMARY KEY,
        Text              NVARCHAR(500)   NOT NULL,
        PreProcessedDate  DATETIME2       NULL,
        CreatedDate       DATETIME2       NOT NULL CONSTRAINT DF_Note_Note_CreatedDate DEFAULT (SYSUTCDATETIME()),
        PostProcessedDate DATETIME2       NULL
    );
END
GO
