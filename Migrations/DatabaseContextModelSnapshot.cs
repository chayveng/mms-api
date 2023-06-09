﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using mms_api.Infrastucture;

#nullable disable

namespace mms_api.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("mms_api.Domain.Bank.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID");

                    b.Property<DateTime>("CREATE_DATETIME")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CREATED_DATETIME");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Image_Id");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Initials");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UPDATE_DATETIME")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UPDATED_DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("mms_api.Domain.Business.Business", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID");

                    b.Property<string>("BusinessId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("BUSINESS_ID");

                    b.Property<DateTime>("CREATE_DATETIME")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CREATED_DATETIME");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("Status");

                    b.Property<DateTime>("UPDATE_DATETIME")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UPDATED_DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("mms_api.Domain.Image.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID");

                    b.Property<DateTime>("CREATED_DATETIME")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CREATED_DATETIME");

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("File");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("IMAGE_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Type");

                    b.Property<DateTime>("UPDATED_DATETIME")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UPDATED_DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("mms_api.Domain.Payment.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("ID");

                    b.Property<DateTime>("CREATED_DATETIME")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CREATED_DATETIME");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Code");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Image_Id");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Initials");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("Status");

                    b.Property<DateTime>("UPDATED_DATETIME")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("UPDATED_DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
