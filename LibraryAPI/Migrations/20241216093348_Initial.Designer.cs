﻿// <auto-generated />
using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(LibraryDBContext))]
    [Migration("20241216093348_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LibraryAPI.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Publisher")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Writer")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LibraryList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Publisher = "Computer",
                            Title = "Test1",
                            Writer = "Ada1"
                        },
                        new
                        {
                            Id = 2,
                            Publisher = "Computer",
                            Title = "Test2",
                            Writer = "Ada2"
                        },
                        new
                        {
                            Id = 3,
                            Publisher = "Computer",
                            Title = "Test3",
                            Writer = "Ada3"
                        },
                        new
                        {
                            Id = 4,
                            Publisher = "Computer",
                            Title = "Test4",
                            Writer = "Ada4"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
