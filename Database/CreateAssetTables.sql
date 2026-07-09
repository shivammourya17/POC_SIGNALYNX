USE [master];
GO

IF DB_ID(N'crud') IS NULL
BEGIN
    CREATE DATABASE [crud];
END
GO

USE [crud];
GO

IF SCHEMA_ID(N'Asset') IS NULL
BEGIN
    EXEC(N'CREATE SCHEMA Asset');
END
GO

IF OBJECT_ID(N'Asset.Asset', N'U') IS NULL
BEGIN
    CREATE TABLE Asset.Asset
    (
        AssetId           INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Asset_Asset PRIMARY KEY,
        AssetTypeId       INT             NOT NULL, -- 0=Other, 1=Copier, 2=Printer
        AssetCategoryId   INT             NOT NULL,
        AssetNo           NVARCHAR(50)    NOT NULL,
        Manufacturer      NVARCHAR(200)   NULL,
        ModelNo           NVARCHAR(100)   NULL,
        SerialNo          NVARCHAR(100)   NULL,
        AssetTagNo        NVARCHAR(100)   NULL,
        ClientId          INT             NOT NULL,
        Location          NVARCHAR(200)   NULL,
        Description       NVARCHAR(500)   NULL,
        ThirdPartyName    NVARCHAR(200)   NULL,
        PhoneNo           NVARCHAR(50)    NULL,
        EmailAddress      NVARCHAR(200)   NULL,
        ColorRate         DECIMAL(10,4)   NULL,
        BwRate            DECIMAL(10,4)   NULL,
        InitialColorMeter INT             NULL,
        InitialBwMeter    INT             NULL,
        CreatedDate       DATETIME2       NOT NULL CONSTRAINT DF_Asset_Asset_CreatedDate DEFAULT (SYSUTCDATETIME()),
        UpdatedDate       DATETIME2       NULL,
        DeletedDate       DATETIME2       NULL
    );
END
GO

IF COL_LENGTH(N'Asset.Asset', N'AssetTypeId') IS NULL
    ALTER TABLE Asset.Asset ADD AssetTypeId INT NOT NULL CONSTRAINT DF_Asset_Asset_AssetTypeId DEFAULT (0) WITH VALUES;
GO

IF COL_LENGTH(N'Asset.Asset', N'AssetCategoryId') IS NULL
    ALTER TABLE Asset.Asset ADD AssetCategoryId INT NOT NULL CONSTRAINT DF_Asset_Asset_AssetCategoryId DEFAULT (0) WITH VALUES;
GO

IF COL_LENGTH(N'Asset.Asset', N'AssetNo') IS NULL
    ALTER TABLE Asset.Asset ADD AssetNo NVARCHAR(50) NOT NULL CONSTRAINT DF_Asset_Asset_AssetNo DEFAULT (N'') WITH VALUES;
GO

IF COL_LENGTH(N'Asset.Asset', N'Manufacturer') IS NULL
    ALTER TABLE Asset.Asset ADD Manufacturer NVARCHAR(200) NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'ModelNo') IS NULL
    ALTER TABLE Asset.Asset ADD ModelNo NVARCHAR(100) NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'SerialNo') IS NULL
    ALTER TABLE Asset.Asset ADD SerialNo NVARCHAR(100) NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'AssetTagNo') IS NULL
    ALTER TABLE Asset.Asset ADD AssetTagNo NVARCHAR(100) NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'ClientId') IS NULL
    ALTER TABLE Asset.Asset ADD ClientId INT NOT NULL CONSTRAINT DF_Asset_Asset_ClientId DEFAULT (0) WITH VALUES;
GO

IF COL_LENGTH(N'Asset.Asset', N'Location') IS NULL
    ALTER TABLE Asset.Asset ADD Location NVARCHAR(200) NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'Description') IS NULL
    ALTER TABLE Asset.Asset ADD Description NVARCHAR(500) NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'ThirdPartyName') IS NULL
    ALTER TABLE Asset.Asset ADD ThirdPartyName NVARCHAR(200) NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'PhoneNo') IS NULL
    ALTER TABLE Asset.Asset ADD PhoneNo NVARCHAR(50) NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'EmailAddress') IS NULL
    ALTER TABLE Asset.Asset ADD EmailAddress NVARCHAR(200) NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'ColorRate') IS NULL
    ALTER TABLE Asset.Asset ADD ColorRate DECIMAL(10,4) NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'BwRate') IS NULL
    ALTER TABLE Asset.Asset ADD BwRate DECIMAL(10,4) NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'InitialColorMeter') IS NULL
    ALTER TABLE Asset.Asset ADD InitialColorMeter INT NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'InitialBwMeter') IS NULL
    ALTER TABLE Asset.Asset ADD InitialBwMeter INT NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'CreatedDate') IS NULL
    ALTER TABLE Asset.Asset ADD CreatedDate DATETIME2 NOT NULL CONSTRAINT DF_Asset_Asset_CreatedDate DEFAULT (SYSUTCDATETIME()) WITH VALUES;
GO

IF COL_LENGTH(N'Asset.Asset', N'UpdatedDate') IS NULL
    ALTER TABLE Asset.Asset ADD UpdatedDate DATETIME2 NULL;
GO

IF COL_LENGTH(N'Asset.Asset', N'DeletedDate') IS NULL
    ALTER TABLE Asset.Asset ADD DeletedDate DATETIME2 NULL;
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = N'IX_Asset_AssetTagNo'
      AND object_id = OBJECT_ID(N'Asset.Asset')
)
BEGIN
    CREATE UNIQUE INDEX IX_Asset_AssetTagNo
        ON Asset.Asset (AssetTagNo)
        WHERE DeletedDate IS NULL AND AssetTagNo IS NOT NULL;
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = N'IX_Asset_ClientId'
      AND object_id = OBJECT_ID(N'Asset.Asset')
)
BEGIN
    CREATE INDEX IX_Asset_ClientId
        ON Asset.Asset (ClientId)
        WHERE DeletedDate IS NULL;
END
GO

SELECT
    DB_NAME() AS DatabaseName,
    OBJECT_SCHEMA_NAME(OBJECT_ID(N'Asset.Asset')) AS SchemaName,
    OBJECT_NAME(OBJECT_ID(N'Asset.Asset')) AS TableName,
    COUNT(1) AS TotalRows
FROM Asset.Asset;
GO
