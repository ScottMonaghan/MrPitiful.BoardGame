IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Games] (
    [Id] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [GameSets] (
    [Id] uniqueidentifier NOT NULL,
    [GameId] uniqueidentifier,
    CONSTRAINT [PK_GameSets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_GameSets_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [GameStateProperties] (
    [GameId] uniqueidentifier NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max),
    CONSTRAINT [PK_GameStateProperties] PRIMARY KEY ([GameId], [Name]),
    CONSTRAINT [FK_GameStateProperties_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Players] (
    [Id] uniqueidentifier NOT NULL,
    [GameId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Players] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Players_Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [Games] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Cards] (
    [Id] uniqueidentifier NOT NULL,
    [GameSetId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Cards] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cards_GameSets_GameSetId] FOREIGN KEY ([GameSetId]) REFERENCES [GameSets] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Decks] (
    [Id] uniqueidentifier NOT NULL,
    [GameSetId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Decks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Decks_GameSets_GameSetId] FOREIGN KEY ([GameSetId]) REFERENCES [GameSets] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Dice] (
    [Id] uniqueidentifier NOT NULL,
    [GameSetId] uniqueidentifier NOT NULL,
    [Sides] int NOT NULL,
    [Value] int NOT NULL,
    CONSTRAINT [PK_Dice] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Dice_GameSets_GameSetId] FOREIGN KEY ([GameSetId]) REFERENCES [GameSets] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [GameBoards] (
    [Id] uniqueidentifier NOT NULL,
    [GameSetId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_GameBoards] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_GameBoards_GameSets_GameSetId] FOREIGN KEY ([GameSetId]) REFERENCES [GameSets] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [GameSetStateProperties] (
    [GameSetId] uniqueidentifier NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max),
    CONSTRAINT [PK_GameSetStateProperties] PRIMARY KEY ([GameSetId], [Name]),
    CONSTRAINT [FK_GameSetStateProperties_GameSets_GameSetId] FOREIGN KEY ([GameSetId]) REFERENCES [GameSets] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [PlayerStateProperties] (
    [PlayerId] uniqueidentifier NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max),
    CONSTRAINT [PK_PlayerStateProperties] PRIMARY KEY ([PlayerId], [Name]),
    CONSTRAINT [FK_PlayerStateProperties_Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [CardStateProperties] (
    [CardId] uniqueidentifier NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max),
    CONSTRAINT [PK_CardStateProperties] PRIMARY KEY ([CardId], [Name]),
    CONSTRAINT [FK_CardStateProperties_Cards_CardId] FOREIGN KEY ([CardId]) REFERENCES [Cards] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [CardsInDecks] (
    [Id] uniqueidentifier NOT NULL,
    [CardId] uniqueidentifier,
    [DeckId] uniqueidentifier NOT NULL,
    [Position] int NOT NULL,
    CONSTRAINT [PK_CardsInDecks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CardsInDecks_Cards_CardId] FOREIGN KEY ([CardId]) REFERENCES [Cards] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CardsInDecks_Decks_DeckId] FOREIGN KEY ([DeckId]) REFERENCES [Decks] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [DeckStateProperties] (
    [DeckId] uniqueidentifier NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max),
    CONSTRAINT [PK_DeckStateProperties] PRIMARY KEY ([DeckId], [Name]),
    CONSTRAINT [FK_DeckStateProperties_Decks_DeckId] FOREIGN KEY ([DeckId]) REFERENCES [Decks] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [DieStateProperties] (
    [DieId] uniqueidentifier NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max),
    CONSTRAINT [PK_DieStateProperties] PRIMARY KEY ([DieId], [Name]),
    CONSTRAINT [FK_DieStateProperties_Dice_DieId] FOREIGN KEY ([DieId]) REFERENCES [Dice] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [GameBoardSpaces] (
    [Id] uniqueidentifier NOT NULL,
    [GameBoardId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_GameBoardSpaces] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_GameBoardSpaces_GameBoards_GameBoardId] FOREIGN KEY ([GameBoardId]) REFERENCES [GameBoards] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [GameBoardStateProperties] (
    [GameBoardId] uniqueidentifier NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max),
    CONSTRAINT [PK_GameBoardStateProperties] PRIMARY KEY ([GameBoardId], [Name]),
    CONSTRAINT [FK_GameBoardStateProperties_GameBoards_GameBoardId] FOREIGN KEY ([GameBoardId]) REFERENCES [GameBoards] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [GameBoardSpaceStateProperties] (
    [GameBoardSpaceId] uniqueidentifier NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max),
    CONSTRAINT [PK_GameBoardSpaceStateProperties] PRIMARY KEY ([GameBoardSpaceId], [Name]),
    CONSTRAINT [FK_GameBoardSpaceStateProperties_GameBoardSpaces_GameBoardSpaceId] FOREIGN KEY ([GameBoardSpaceId]) REFERENCES [GameBoardSpaces] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [GamePieces] (
    [Id] uniqueidentifier NOT NULL,
    [GameBoardSpaceId] uniqueidentifier,
    [GameSetId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_GamePieces] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_GamePieces_GameBoardSpaces_GameBoardSpaceId] FOREIGN KEY ([GameBoardSpaceId]) REFERENCES [GameBoardSpaces] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_GamePieces_GameSets_GameSetId] FOREIGN KEY ([GameSetId]) REFERENCES [GameSets] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [SpaceConnections] (
    [Id] uniqueidentifier NOT NULL,
    [GameBoardSpaceId] uniqueidentifier NOT NULL,
    [RemoteSpaceId] uniqueidentifier,
    CONSTRAINT [PK_SpaceConnections] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SpaceConnections_GameBoardSpaces_GameBoardSpaceId] FOREIGN KEY ([GameBoardSpaceId]) REFERENCES [GameBoardSpaces] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SpaceConnections_GameBoardSpaces_RemoteSpaceId] FOREIGN KEY ([RemoteSpaceId]) REFERENCES [GameBoardSpaces] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [GamePieceStateProperties] (
    [GamePieceId] uniqueidentifier NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max),
    CONSTRAINT [PK_GamePieceStateProperties] PRIMARY KEY ([GamePieceId], [Name]),
    CONSTRAINT [FK_GamePieceStateProperties_GamePieces_GamePieceId] FOREIGN KEY ([GamePieceId]) REFERENCES [GamePieces] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [SpaceConnectionStateProperties] (
    [SpaceConnectionId] uniqueidentifier NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max),
    CONSTRAINT [PK_SpaceConnectionStateProperties] PRIMARY KEY ([SpaceConnectionId], [Name]),
    CONSTRAINT [FK_SpaceConnectionStateProperties_SpaceConnections_SpaceConnectionId] FOREIGN KEY ([SpaceConnectionId]) REFERENCES [SpaceConnections] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Cards_GameSetId] ON [Cards] ([GameSetId]);

GO

CREATE UNIQUE INDEX [IX_CardsInDecks_CardId] ON [CardsInDecks] ([CardId]) WHERE [CardId] IS NOT NULL;

GO

CREATE INDEX [IX_CardsInDecks_DeckId] ON [CardsInDecks] ([DeckId]);

GO

CREATE INDEX [IX_CardStateProperties_CardId] ON [CardStateProperties] ([CardId]);

GO

CREATE INDEX [IX_Decks_GameSetId] ON [Decks] ([GameSetId]);

GO

CREATE INDEX [IX_DeckStateProperties_DeckId] ON [DeckStateProperties] ([DeckId]);

GO

CREATE INDEX [IX_Dice_GameSetId] ON [Dice] ([GameSetId]);

GO

CREATE INDEX [IX_DieStateProperties_DieId] ON [DieStateProperties] ([DieId]);

GO

CREATE UNIQUE INDEX [IX_GameBoards_GameSetId] ON [GameBoards] ([GameSetId]) WHERE [GameSetId] IS NOT NULL;

GO

CREATE INDEX [IX_GameBoardSpaces_GameBoardId] ON [GameBoardSpaces] ([GameBoardId]);

GO

CREATE INDEX [IX_GameBoardSpaceStateProperties_GameBoardSpaceId] ON [GameBoardSpaceStateProperties] ([GameBoardSpaceId]);

GO

CREATE INDEX [IX_GameBoardStateProperties_GameBoardId] ON [GameBoardStateProperties] ([GameBoardId]);

GO

CREATE INDEX [IX_GamePieces_GameBoardSpaceId] ON [GamePieces] ([GameBoardSpaceId]);

GO

CREATE INDEX [IX_GamePieces_GameSetId] ON [GamePieces] ([GameSetId]);

GO

CREATE INDEX [IX_GamePieceStateProperties_GamePieceId] ON [GamePieceStateProperties] ([GamePieceId]);

GO

CREATE UNIQUE INDEX [IX_GameSets_GameId] ON [GameSets] ([GameId]) WHERE [GameId] IS NOT NULL;

GO

CREATE INDEX [IX_GameSetStateProperties_GameSetId] ON [GameSetStateProperties] ([GameSetId]);

GO

CREATE INDEX [IX_GameStateProperties_GameId] ON [GameStateProperties] ([GameId]);

GO

CREATE INDEX [IX_Players_GameId] ON [Players] ([GameId]);

GO

CREATE INDEX [IX_PlayerStateProperties_PlayerId] ON [PlayerStateProperties] ([PlayerId]);

GO

CREATE INDEX [IX_SpaceConnections_GameBoardSpaceId] ON [SpaceConnections] ([GameBoardSpaceId]);

GO

CREATE INDEX [IX_SpaceConnections_RemoteSpaceId] ON [SpaceConnections] ([RemoteSpaceId]);

GO

CREATE INDEX [IX_SpaceConnectionStateProperties_SpaceConnectionId] ON [SpaceConnectionStateProperties] ([SpaceConnectionId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20161123205657_initialMigration', N'1.0.1');

GO

