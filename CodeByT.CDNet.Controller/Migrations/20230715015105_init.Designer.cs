﻿// <auto-generated />
using System;
using CodeByT.CDNet.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeByT.CDNet.Controller.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20230715015105_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CodeByT.CDNet.Models.Data_Models.Image", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("base64")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("contentType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("fileName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Images", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
