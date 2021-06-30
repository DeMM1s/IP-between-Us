﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebAPI.Database;

namespace MyWebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWebAPI.Models.IPInfo", b =>
                {
                    b.Property<string>("StartIP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EndIP")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IntermediateIP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StartIP", "EndIP");

                    b.ToTable("IPInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
