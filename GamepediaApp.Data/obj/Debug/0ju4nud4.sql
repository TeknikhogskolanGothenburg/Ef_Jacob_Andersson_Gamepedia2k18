IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Countries] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [CountryCode] nvarchar(2) NULL,
    [FlagImage] image NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Maps] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Launch] datetime2 NOT NULL,
    CONSTRAINT [PK_Maps] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Players] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [BirthDate] datetime2 NOT NULL,
    [NickName] nvarchar(max) NULL,
    [Role] nvarchar(max) NULL,
    [Status] nvarchar(max) NULL,
    [CountryId] int NOT NULL,
    CONSTRAINT [PK_Players] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Players_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Teams] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [TeamLogo] image NULL,
    [Founded] datetime2 NOT NULL,
    [CountryId] int NOT NULL,
    CONSTRAINT [PK_Teams] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Teams_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [TeamPlayers] (
    [PlayerId] int NOT NULL,
    [TeamId] int NOT NULL,
    CONSTRAINT [PK_TeamPlayers] PRIMARY KEY ([PlayerId], [TeamId]),
    CONSTRAINT [FK_TeamPlayers_Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TeamPlayers_Teams_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Teams] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Tournaments] (
    [Id] int NOT NULL IDENTITY,
    [Tier] nvarchar(max) NULL,
    [GameName] nvarchar(max) NULL,
    [TournamentName] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [PriceMoney] int NOT NULL,
    [CountryId] int NOT NULL,
    [TeamWinnerId] int NOT NULL,
    CONSTRAINT [PK_Tournaments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tournaments_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Tournaments_Teams_TeamWinnerId] FOREIGN KEY ([TeamWinnerId]) REFERENCES [Teams] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [TournamentMaps] (
    [MapId] int NOT NULL,
    [TournamentId] int NOT NULL,
    CONSTRAINT [PK_TournamentMaps] PRIMARY KEY ([TournamentId], [MapId]),
    CONSTRAINT [FK_TournamentMaps_Maps_MapId] FOREIGN KEY ([MapId]) REFERENCES [Maps] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TournamentMaps_Tournaments_TournamentId] FOREIGN KEY ([TournamentId]) REFERENCES [Tournaments] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Players_CountryId] ON [Players] ([CountryId]);

GO

CREATE INDEX [IX_TeamPlayers_TeamId] ON [TeamPlayers] ([TeamId]);

GO

CREATE INDEX [IX_Teams_CountryId] ON [Teams] ([CountryId]);

GO

CREATE INDEX [IX_TournamentMaps_MapId] ON [TournamentMaps] ([MapId]);

GO

CREATE INDEX [IX_Tournaments_CountryId] ON [Tournaments] ([CountryId]);

GO

CREATE INDEX [IX_Tournaments_TeamWinnerId] ON [Tournaments] ([TeamWinnerId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180329085953_init', N'2.1.0-preview1-28290');

GO

