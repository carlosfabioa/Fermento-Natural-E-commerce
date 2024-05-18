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

CREATE TABLE [usuario] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(max) NOT NULL,
    [email] nvarchar(max) NOT NULL,
    [senha] nvarchar(max) NOT NULL,
    [endereço] nvarchar(max) NOT NULL,
    [celular] int NOT NULL,
    CONSTRAINT [PK_usuario] PRIMARY KEY ([id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240503000825_usuario', N'7.0.18');
GO

COMMIT;
GO

