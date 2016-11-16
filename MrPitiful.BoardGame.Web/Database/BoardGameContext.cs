using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MrPitiful.BoardGame.Models;

namespace MrPitiful.BoardGame.Database
{
    public class BoardGameContext:DbContext
    {
        public BoardGameContext(DbContextOptions<BoardGameContext> options)
            : base(options)
        { }
        //public DbSet<StateProperty> GameStateProperties { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameStateProperty> GameStateProperties { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStateProperty> PlayerStateProperties { get; set; }
        public DbSet<GameSet> GameSets { get; set; }
        public DbSet<GameSetStateProperty> GameSetStateProperties { get; set; }
        public DbSet<GameBoard> GameBoards { get; set; }
        public DbSet<GameBoardStateProperty> GameBoardStateProperties { get; set; }
        public DbSet<GameBoardSpace> GameBoardSpaces { get; set; }
        public DbSet<GameBoardSpaceStateProperty> GameBoardSpaceStateProperties { get; set; }
        public DbSet<SpaceConnection> SpaceConnections { get; set; }
        public DbSet<SpaceConnectionStateProperty> SpaceConnectionStateProperties { get; set; }
        public DbSet<GamePiece> GamePieces { get; set; }
        public DbSet<GamePieceStateProperty> GamePieceStateProperties { get; set; }
        public DbSet<Die> Dice { get; set; }
        public DbSet<DieStateProperty> DieStateProperties { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardStateProperty> CardStateProperties { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<DeckStateProperty> DeckStateProperties { get; set; }
        public DbSet<CardInDeck> CardsInDecks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CardInDeck>()
                .HasOne(cid => cid.Card)
                .WithOne(c => c.CardInDeck)
                .IsRequired(false);

            modelBuilder.Entity<GameSet>()
                    .HasOne(gs => gs.Game)
                    .WithOne(g => g.GameSet)
                    .IsRequired(false);

            modelBuilder.Entity<SpaceConnection>()
                    .HasOne(sc => sc.GameBoardSpace)
                    .WithMany(gbs => gbs.SpaceConnections)
                    .HasForeignKey(ajs => ajs.GameBoardSpaceId);
            modelBuilder.Entity<SpaceConnection>()
                .HasOne(adj => adj.RemoteSpace);

            modelBuilder.Entity<GameStateProperty>()
                .HasKey(x => new { x.GameId, x.Name });
            modelBuilder.Entity<PlayerStateProperty>()
                .HasKey(x => new { x.PlayerId, x.Name });
            modelBuilder.Entity<GameSetStateProperty>()
                .HasKey(x => new { x.GameSetId, x.Name });
            modelBuilder.Entity<GameBoardStateProperty>()
                .HasKey(x => new { x.GameBoardId, x.Name });
            modelBuilder.Entity<GameBoardSpaceStateProperty>()
                .HasKey(x => new { x.GameBoardSpaceId, x.Name });
            modelBuilder.Entity<SpaceConnectionStateProperty>()
                .HasKey(x => new { x.SpaceConnectionId, x.Name });
            modelBuilder.Entity<GamePieceStateProperty>()
                .HasKey(x => new { x.GamePieceId, x.Name });
            modelBuilder.Entity<DieStateProperty>()
                .HasKey(x => new { x.DieId, x.Name });
            modelBuilder.Entity<CardStateProperty>()
                .HasKey(x => new { x.CardId, x.Name });
            modelBuilder.Entity<DeckStateProperty>()
                .HasKey(x => new { x.DeckId, x.Name });
        }
    }
}
