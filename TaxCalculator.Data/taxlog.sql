IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TaxPostCodes] (
    [Id] bigint NOT NULL IDENTITY,
    [PostalCode] nvarchar(max) NOT NULL,
    [TaxType] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_TaxPostCodes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TaxRates] (
    [Id] bigint NOT NULL IDENTITY,
    [From] decimal(18,2) NOT NULL,
    [To] decimal(18,2) NOT NULL,
    [RatePercentage] decimal(18,2) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_TaxRates] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TaxTypes] (
    [Id] bigint NOT NULL IDENTITY,
    [Type] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_TaxTypes] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231207210749_initial', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [CalculatedTaxes] (
    [Id] bigint NOT NULL IDENTITY,
    [Tax] decimal(18,2) NOT NULL,
    [PostCode] nvarchar(max) NOT NULL,
    [Income] decimal(18,2) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    [UpdatedAt] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [UpdatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_CalculatedTaxes] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231209140007_taxlog', N'7.0.0');
GO

COMMIT;
GO

