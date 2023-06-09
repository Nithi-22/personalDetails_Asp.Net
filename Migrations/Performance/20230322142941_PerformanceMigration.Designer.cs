﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace personaldetails.Migrations.Performance
{
    [DbContext(typeof(PerformanceContext))]
    [Migration("20230322142941_PerformanceMigration")]
    partial class PerformanceMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("personaldetails.Models.Performance", b =>
                {
                    b.Property<int>("empid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("empid"));

                    b.Property<string>("empemail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("team_lead")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("team_manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("team_mem1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("team_mem2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("team_mem3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("team_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("empid");

                    b.ToTable("performancedetails");
                });
#pragma warning restore 612, 618
        }
    }
}
