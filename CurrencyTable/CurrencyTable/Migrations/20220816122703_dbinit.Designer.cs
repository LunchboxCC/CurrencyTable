﻿// <auto-generated />
using System;
using CurrencyTable.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CurrencyTable.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220816122703_dbinit")]
    partial class dbinit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CurrencyTable.Models.Entities.Currency", b =>
                {
                    b.Property<long>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CurrencyId"), 1L, 1);

                    b.Property<short>("Amount")
                        .HasColumnType("smallint");

                    b.Property<double>("CnbMid")
                        .HasColumnType("float");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<double>("CurrBuy")
                        .HasColumnType("float");

                    b.Property<double>("CurrMid")
                        .HasColumnType("float");

                    b.Property<double>("CurrSell")
                        .HasColumnType("float");

                    b.Property<double>("EcbMid")
                        .HasColumnType("float");

                    b.Property<double>("Move")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("varchar(20)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<double>("ValBuy")
                        .HasColumnType("float");

                    b.Property<double>("ValMid")
                        .HasColumnType("float");

                    b.Property<double>("ValSell")
                        .HasColumnType("float");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<short>("Version")
                        .HasColumnType("smallint");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currencies");
                });
#pragma warning restore 612, 618
        }
    }
}
