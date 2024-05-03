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

CREATE TABLE [Pao] (
    [id] int NOT NULL IDENTITY,
    [tipo] nvarchar(max) NOT NULL,
    [tipoFermentacao] nvarchar(max) NOT NULL,
    [fornada] nvarchar(max) NOT NULL,
    [preco] float NOT NULL,
    CONSTRAINT [PK_Pao] PRIMARY KEY ([id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240503002218_addpao', N'7.0.18');
GO

COMMIT;
GO

