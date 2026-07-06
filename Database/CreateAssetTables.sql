USE [1TFMDB];
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Asset')
BEGIN
    EXEC('CREATE SCHEMA Asset');
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Asset' AND schema_id = SCHEMA_ID('Asset'))
BEGIN
    CREATE TABLE Asset.Asset
    (
        AssetId           INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        AssetTypeId       INT             NOT NULL,               -- 0=Other, 1=Copier, 2=Printer (see AssetType enum)
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
        CreatedDate       DATETIME2       NOT NULL DEFAULT (SYSUTCDATETIME()),
        UpdatedDate       DATETIME2       NULL,
        DeletedDate       DATETIME2       NULL
    );

    CREATE UNIQUE INDEX IX_Asset_AssetTagNo ON Asset.Asset (AssetTagNo) WHERE DeletedDate IS NULL AND AssetTagNo IS NOT NULL;
    CREATE INDEX IX_Asset_ClientId ON Asset.Asset (ClientId) WHERE DeletedDate IS NULL;
END
GO
