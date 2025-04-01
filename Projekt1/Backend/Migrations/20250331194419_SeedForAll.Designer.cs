﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250331194419_SeedForAll")]
    partial class SeedForAll
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.Auditorium", b =>
                {
                    b.Property<int>("AuditoriumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuditoriumId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatCount")
                        .HasColumnType("int");

                    b.HasKey("AuditoriumId");

                    b.ToTable("Auditoriums");

                    b.HasData(
                        new
                        {
                            AuditoriumId = 1,
                            Name = "Auditorium A",
                            SeatCount = 100
                        },
                        new
                        {
                            AuditoriumId = 2,
                            Name = "Auditorium B",
                            SeatCount = 80
                        });
                });

            modelBuilder.Entity("Backend.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("ShowId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            BookingId = 1,
                            CustomerEmail = "johndoe@example.com",
                            CustomerName = "John Doe",
                            EndDate = new DateTime(2025, 4, 1, 23, 44, 18, 753, DateTimeKind.Local).AddTicks(3769),
                            ShowId = 1,
                            StartDate = new DateTime(2025, 4, 1, 21, 44, 18, 753, DateTimeKind.Local).AddTicks(3576),
                            Status = 1,
                            UserId = 1
                        },
                        new
                        {
                            BookingId = 2,
                            CustomerEmail = "janesmith@example.com",
                            CustomerName = "Jane Smith",
                            EndDate = new DateTime(2025, 4, 2, 23, 44, 18, 753, DateTimeKind.Local).AddTicks(4541),
                            ShowId = 2,
                            StartDate = new DateTime(2025, 4, 2, 21, 44, 18, 753, DateTimeKind.Local).AddTicks(4533),
                            Status = 0,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Backend.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Description = "A mind-bending thriller about dreams within dreams.",
                            DurationInMinutes = 148,
                            Title = "Inception"
                        },
                        new
                        {
                            MovieId = 2,
                            Description = "A hacker discovers the shocking truth about his reality.",
                            DurationInMinutes = 136,
                            Title = "The Matrix"
                        });
                });

            modelBuilder.Entity("Backend.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"));

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("Row")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("SeatId");

                    b.HasIndex("BookingId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Backend.Models.Show", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShowId"));

                    b.Property<int>("AuditoriumId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("MovieTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.HasKey("ShowId");

                    b.HasIndex("AuditoriumId");

                    b.HasIndex("MovieId");

                    b.ToTable("Shows");

                    b.HasData(
                        new
                        {
                            ShowId = 1,
                            AuditoriumId = 1,
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 1,
                            MovieTitle = "Inception",
                            StartDate = new DateTime(2025, 4, 1, 21, 44, 18, 749, DateTimeKind.Local).AddTicks(3843),
                            TotalSeats = 0
                        },
                        new
                        {
                            ShowId = 2,
                            AuditoriumId = 2,
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MovieId = 2,
                            MovieTitle = "The Matrix",
                            StartDate = new DateTime(2025, 4, 2, 21, 44, 18, 752, DateTimeKind.Local).AddTicks(9907),
                            TotalSeats = 0
                        });
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("DummyColumn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            DummyColumn = "Temp",
                            Password = "$2a$11$K7tih2DcSVCdM9LTf5lmne41uEffe6LXZHT7AmV4mGc4/vbB1NIiG",
                            Role = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            DummyColumn = "Temp",
                            Password = "$2a$11$ymlFcuiFXHLSXD3yEvFp5uFrvkf8FIT6wn/nQYDYgb7B.O0T4oTYS",
                            Role = "User",
                            Username = "user"
                        });
                });

            modelBuilder.Entity("Backend.Models.Booking", b =>
                {
                    b.HasOne("Backend.Models.Show", "Show")
                        .WithMany("Bookings")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Show");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Models.Seat", b =>
                {
                    b.HasOne("Backend.Models.Booking", "Booking")
                        .WithMany("Seats")
                        .HasForeignKey("BookingId");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Backend.Models.Show", b =>
                {
                    b.HasOne("Backend.Models.Auditorium", "Auditorium")
                        .WithMany("Shows")
                        .HasForeignKey("AuditoriumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Movie", "Movie")
                        .WithMany("Shows")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auditorium");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Backend.Models.Auditorium", b =>
                {
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("Backend.Models.Booking", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("Backend.Models.Movie", b =>
                {
                    b.Navigation("Shows");
                });

            modelBuilder.Entity("Backend.Models.Show", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
