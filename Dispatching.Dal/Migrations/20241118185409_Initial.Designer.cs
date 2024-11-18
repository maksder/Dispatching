﻿// <auto-generated />
using System;
using Dispatching.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dispatching.Dal.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    [Migration("20241118185409_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dispatching.Domain.CircuitBoards.CircuitBoard", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("QualityControlResult")
                        .HasColumnType("text")
                        .HasColumnName("quality_control_result");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("circuit_boards", (string)null);
                });

            modelBuilder.Entity("Dispatching.Domain.History.HistoryEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date_time");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<Guid[]>("_participants")
                        .IsRequired()
                        .HasColumnType("uuid[]")
                        .HasColumnName("participants");

                    b.HasKey("Id");

                    b.ToTable("history_events", (string)null);
                });

            modelBuilder.Entity("Dispatching.Domain.CircuitBoards.CircuitBoard", b =>
                {
                    b.OwnsMany("Dispatching.Domain.CircuitBoards.CircuitBoardComponent", "Components", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<Guid>("CircuitBoardId")
                                .HasColumnType("uuid")
                                .HasColumnName("circuit_board_id");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("name");

                            b1.HasKey("Id", "CircuitBoardId");

                            b1.HasIndex("CircuitBoardId");

                            b1.ToTable("circuit_board_components", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("CircuitBoardId");
                        });

                    b.Navigation("Components");
                });
#pragma warning restore 612, 618
        }
    }
}