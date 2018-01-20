﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MMA_site_app.Data;
using System;

namespace MMA_site_app.Migrations
{
    [DbContext(typeof(FighterContext))]
    partial class FighterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MMA_site_app.Models.Fighter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Age");

                    b.Property<string>("FightsOutOf");

                    b.Property<string>("FirstName");

                    b.Property<string>("From");

                    b.Property<string>("Height");

                    b.Property<string>("HeightCm");

                    b.Property<string>("ImageInList");

                    b.Property<string>("ImageMainProfile");

                    b.Property<string>("LastName");

                    b.Property<string>("LegReach");

                    b.Property<string>("Nickname");

                    b.Property<string>("Reach");

                    b.Property<string>("Record");

                    b.Property<string>("Summary");

                    b.Property<string>("Weight");

                    b.Property<string>("WeightKg");

                    b.HasKey("ID");

                    b.ToTable("Fighter");
                });

            modelBuilder.Entity("MMA_site_app.Models.Perfomanse", b =>
                {
                    b.Property<int>("PerfomanseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<string>("EnemyLink");

                    b.Property<string>("EnemyName");

                    b.Property<int>("FighterID");

                    b.Property<string>("Method");

                    b.Property<string>("Result");

                    b.Property<int?>("Round");

                    b.Property<string>("Time");

                    b.Property<string>("Tournament");

                    b.Property<string>("Video");

                    b.HasKey("PerfomanseID");

                    b.HasIndex("FighterID");

                    b.ToTable("Perfomanse");
                });

            modelBuilder.Entity("MMA_site_app.Models.TitleHolder", b =>
                {
                    b.Property<int>("TitleHolderID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("ImageTitle");

                    b.Property<string>("LastName");

                    b.Property<int>("Order");

                    b.Property<string>("ProfileLink");

                    b.Property<string>("Record");

                    b.Property<string>("WeightCategory");

                    b.HasKey("TitleHolderID");

                    b.ToTable("TitleHolder");
                });

            modelBuilder.Entity("MMA_site_app.Models.Perfomanse", b =>
                {
                    b.HasOne("MMA_site_app.Models.Fighter")
                        .WithMany("Perfomanses")
                        .HasForeignKey("FighterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}