IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'MovieRent') IS NULL EXEC(N'CREATE SCHEMA [MovieRent];');

GO

CREATE TABLE [MovieRent].[Movies] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(50) NOT NULL,
    [Duration] int NOT NULL,
    [Author] nvarchar(50) NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MovieRent].[Users] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [EmailAddress] nvarchar(50) NOT NULL,
    [Password] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MovieRent].[Rentals] (
    [Id] int NOT NULL IDENTITY,
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    [RentalDate] datetime NOT NULL DEFAULT (getdate()),
    [ReturnDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Rentals] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Rentals_Movies_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [MovieRent].[Movies] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Rentals_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [MovieRent].[Users] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Rentals_MovieId] ON [MovieRent].[Rentals] ([MovieId]);

GO

CREATE INDEX [IX_Rentals_UserId] ON [MovieRent].[Rentals] ([UserId]);

GO

CREATE UNIQUE INDEX [IX_Customers] ON [MovieRent].[Users] ([EmailAddress]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201028210825_Initial', N'2.1.1-rtm-30846');

GO

