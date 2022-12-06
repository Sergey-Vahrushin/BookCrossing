﻿// <auto-generated />
using BookCrossing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookCrossing.Migrations
{
    [DbContext(typeof(AppDBContent))]
    partial class AppDBContentModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("BookCrossing.Data.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Genre");

                    b.Property<string>("Name");

                    b.Property<int>("PublicationYear");

                    b.Property<string>("Publisher");

                    b.HasKey("Id");

                    b.ToTable("Book");
                });
#pragma warning restore 612, 618
        }
    }
}