﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eatery_manager_server.Data.Db;

#nullable disable

namespace eaterymanagerserver.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250612204045_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("eatery_manager_server.Data.Models.Login", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("eatery_manager_server.Data.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Order")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("eatery_manager_server.Data.Models.Reservations", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TableId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TablesTableId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservationId");

                    b.HasIndex("TablesTableId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("eatery_manager_server.Data.Models.Tables", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocationX")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationY")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TableId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("eatery_manager_server.Data.Models.Reservations", b =>
                {
                    b.HasOne("eatery_manager_server.Data.Models.Tables", "Tables")
                        .WithMany()
                        .HasForeignKey("TablesTableId");

                    b.Navigation("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}
