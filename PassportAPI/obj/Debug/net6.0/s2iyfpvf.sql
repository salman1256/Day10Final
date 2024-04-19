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

CREATE TABLE [Passport] (
    [Id] int NOT NULL IDENTITY,
    [HolderName] nvarchar(50) NOT NULL,
    [PassportNumber] nvarchar(10) NOT NULL,
    [Expiry] nvarchar(5) NOT NULL,
    [POCode] nvarchar(6) NOT NULL,
    CONSTRAINT [PK_Passport] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240419090453_IntialMig', N'7.0.10');
GO

COMMIT;
GO

