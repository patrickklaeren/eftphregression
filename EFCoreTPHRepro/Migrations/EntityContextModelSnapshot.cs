﻿// <auto-generated />
using EFCoreTPHRepro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreTPHRepro.Migrations
{
    [DbContext(typeof(EntityContext))]
    partial class EntityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreTPHRepro.Shape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shapes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Shape");
                });

            modelBuilder.Entity("EFCoreTPHRepro.Circle", b =>
                {
                    b.HasBaseType("EFCoreTPHRepro.Shape");

                    b.HasDiscriminator().HasValue("Circle");
                });

            modelBuilder.Entity("EFCoreTPHRepro.Pentagon", b =>
                {
                    b.HasBaseType("EFCoreTPHRepro.Shape");

                    b.HasDiscriminator().HasValue("Pentagon");
                });

            modelBuilder.Entity("EFCoreTPHRepro.Rectangle", b =>
                {
                    b.HasBaseType("EFCoreTPHRepro.Shape");

                    b.HasDiscriminator().HasValue("Rectangle");
                });

            modelBuilder.Entity("EFCoreTPHRepro.Square", b =>
                {
                    b.HasBaseType("EFCoreTPHRepro.Shape");

                    b.HasDiscriminator().HasValue("Square");
                });
#pragma warning restore 612, 618
        }
    }
}