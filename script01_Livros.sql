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

CREATE TABLE [TB_LIVRO] (
    [Id] int NOT NULL IDENTITY,
    [NomedoLivro] nvarchar(max) NOT NULL,
    [Autor] nvarchar(max) NOT NULL,
    [Genero] nvarchar(max) NOT NULL,
    [DataLivro] nvarchar(max) NOT NULL,
    [preco] decimal(18,2) NOT NULL,
    [Disponibilidade] bit NOT NULL,
    CONSTRAINT [PK_TB_LIVRO] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Autor', N'DataLivro', N'Disponibilidade', N'Genero', N'NomedoLivro', N'preco') AND [object_id] = OBJECT_ID(N'[TB_LIVRO]'))
    SET IDENTITY_INSERT [TB_LIVRO] ON;
INSERT INTO [TB_LIVRO] ([Id], [Autor], [DataLivro], [Disponibilidade], [Genero], [NomedoLivro], [preco])
VALUES (1, N'Deus', N'Desconhecido', CAST(1 AS bit), N'Livro Sagrado', N'Bíblia', 50.0),
(2, N'George Orwell', N'1949', CAST(1 AS bit), N'Ficção política', N'1984', 30.0),
(3, N'Charlie Mackesy', N'2020', CAST(1 AS bit), N'Animação', N'O Menino, a Toupeira, a Raposa e o Cavalo', 60.0),
(4, N'Charles Duhigg', N'2012', CAST(1 AS bit), N'Livro de autoajuda', N'O Poder do Hábito', 55.0),
(5, N'Christian Barbosa', N'2008', CAST(1 AS bit), N'Livro de autoajuda', N'A tríade do tempo', 40.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Autor', N'DataLivro', N'Disponibilidade', N'Genero', N'NomedoLivro', N'preco') AND [object_id] = OBJECT_ID(N'[TB_LIVRO]'))
    SET IDENTITY_INSERT [TB_LIVRO] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240430222408_MigracaoInicial', N'8.0.6');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_USUARIOS] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] float NULL,
    [longitude] float NULL,
    [DataAcesso] datetime2 NULL,
    [Perfil] nvarchar(max) NOT NULL DEFAULT N'Jogador',
    [Email] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username', N'longitude') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Id], [DataAcesso], [Email], [Foto], [Latitude], [PasswordHash], [PasswordSalt], [Perfil], [Username], [longitude])
VALUES (1, NULL, N'seuEmail@gmail.com', NULL, -23.520024100000001E0, 0x0A1EB50A8FE0360F876BDF01D4C00E73C1260C168495B1118A8C2B8426E36FFB83816B4153953EB2D8EB7E66A05620945ACC4C208B5E77B71D451AC5F0C86A41, 0x0638AEE800C89127FE00148A9D06108EBD537A1B7287EFBA616D7DB7AE553DC641BDE5B8A75426710E2C932118147EC05A97E467E7F5B10C5200B581BB0DE776BCF479131AC57F7919EBF42384E141102651472E1C2C2F1E038D842433FA9B0F8B87FFC305C2A7174B0E242A706BAB06097B5981577C246462A5433EDB3B6B56, N'Admin', N'UsuarioAmin', -46.596497999999997E0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username', N'longitude') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240615234643_Usuario', N'8.0.6');
GO

COMMIT;
GO

