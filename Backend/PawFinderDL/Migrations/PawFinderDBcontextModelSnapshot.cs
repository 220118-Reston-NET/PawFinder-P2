﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PawFinderDL;

#nullable disable

namespace PawFinderDL.Migrations
{
    [DbContext(typeof(PawFinderDBcontext))]
    partial class PawFinderDBcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PawFinderModel.Like", b =>
                {
                    b.Property<int>("LikedID")
                        .HasColumnType("int");

                    b.Property<int>("LikerID")
                        .HasColumnType("int");

                    b.HasIndex("LikedID");

                    b.HasIndex("LikerID");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("PawFinderModel.Match", b =>
                {
                    b.Property<int>("MatcherOneID")
                        .HasColumnType("int");

                    b.Property<int>("MatcherTwoID")
                        .HasColumnType("int");

                    b.HasIndex("MatcherOneID");

                    b.HasIndex("MatcherTwoID");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("PawFinderModel.Message", b =>
                {
                    b.Property<int>("messageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("messageID"), 1L, 1);

                    b.Property<int>("ReceiverID")
                        .HasColumnType("int");

                    b.Property<int>("SenderID")
                        .HasColumnType("int");

                    b.Property<string>("messageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("messageTimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("messageID");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("SenderID");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("PawFinderModel.Pass", b =>
                {
                    b.Property<int>("PasseeID")
                        .HasColumnType("int");

                    b.Property<int>("PasserID")
                        .HasColumnType("int");

                    b.HasIndex("PasseeID");

                    b.HasIndex("PasserID");

                    b.ToTable("Pass");
                });

            modelBuilder.Entity("PawFinderModel.Photo", b =>
                {
                    b.Property<int>("photoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("photoID"), 1L, 1);

                    b.Property<string>("fileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("photoID");

                    b.HasIndex("userID");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("PawFinderModel.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("UserBio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserBreed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UserDOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PawFinderModel.Like", b =>
                {
                    b.HasOne("PawFinderModel.User", "Liked")
                        .WithMany()
                        .HasForeignKey("LikedID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PawFinderModel.User", "Liker")
                        .WithMany()
                        .HasForeignKey("LikerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Liked");

                    b.Navigation("Liker");
                });

            modelBuilder.Entity("PawFinderModel.Match", b =>
                {
                    b.HasOne("PawFinderModel.User", "MatcherOne")
                        .WithMany()
                        .HasForeignKey("MatcherOneID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PawFinderModel.User", "MatcherTwo")
                        .WithMany()
                        .HasForeignKey("MatcherTwoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MatcherOne");

                    b.Navigation("MatcherTwo");
                });

            modelBuilder.Entity("PawFinderModel.Message", b =>
                {
                    b.HasOne("PawFinderModel.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PawFinderModel.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("PawFinderModel.Pass", b =>
                {
                    b.HasOne("PawFinderModel.User", "Passee")
                        .WithMany()
                        .HasForeignKey("PasseeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PawFinderModel.User", "Passer")
                        .WithMany()
                        .HasForeignKey("PasserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Passee");

                    b.Navigation("Passer");
                });

            modelBuilder.Entity("PawFinderModel.Photo", b =>
                {
                    b.HasOne("PawFinderModel.User", null)
                        .WithMany("Photo")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PawFinderModel.User", b =>
                {
                    b.Navigation("Photo");
                });
#pragma warning restore 612, 618
        }
    }
}