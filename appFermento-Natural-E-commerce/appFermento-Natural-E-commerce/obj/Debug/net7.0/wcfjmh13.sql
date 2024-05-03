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

CREATE TABLE [Usuario] (
    [id] int NOT NULL IDENTITY,
    [nome] nvarchar(100) NOT NULL,
    [email] nvarchar(100) NOT NULL,
    [senha] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240502225248_CadastroInitial', N'7.0.18');
GO

COMMIT;
GO

