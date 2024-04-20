﻿// <auto-generated />
using HighScorePlayerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HighScorePlayerAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("HighScorePlayerAPI.Models.Game", b =>
                {
                    b.Property<int>("Game_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Game_Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("HighScorePlayerAPI.Models.HighScore", b =>
                {
                    b.Property<int>("HighScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("HighScoreId");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("HighScores");
                });

            modelBuilder.Entity("HighScorePlayerAPI.Models.Player", b =>
                {
                    b.Property<int>("Player_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Player_Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("HighScorePlayerAPI.Models.HighScore", b =>
                {
                    b.HasOne("HighScorePlayerAPI.Models.Game", "Game")
                        .WithMany("HighScores")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HighScorePlayerAPI.Models.Player", "Player")
                        .WithMany("HighScores")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("HighScorePlayerAPI.Models.Game", b =>
                {
                    b.Navigation("HighScores");
                });

            modelBuilder.Entity("HighScorePlayerAPI.Models.Player", b =>
                {
                    b.Navigation("HighScores");
                });
#pragma warning restore 612, 618
        }
    }
}
