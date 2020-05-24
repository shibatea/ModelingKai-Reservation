﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservation.Infrastructure.SQLite.Reservation;

namespace Reservation.Infrastructure.SQLite.Migrations
{
    [DbContext(typeof(ReservationContext))]
    [Migration("20200524123824_4th")]
    partial class _4th
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("Reservation.Infrastructure.SQLite.Reservation.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoomName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(20);

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
