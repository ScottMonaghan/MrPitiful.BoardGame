using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MrPitiful.SlackChess;

namespace MrPitiful.SlackChess.Migrations
{
    [DbContext(typeof(SlackChessGameDbContext))]
    [Migration("20161012014259_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MrPitiful.SlackChess.SlackChessGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SlackChannelId");

                    b.Property<Guid>("UnicodeChessGameId");

                    b.HasKey("Id");

                    b.ToTable("SlackChessGames");
                });
        }
    }
}
