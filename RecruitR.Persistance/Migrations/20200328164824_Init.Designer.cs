﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RecruitR.Persistence;

namespace RecruitR.Persistence.Migrations
{
    [DbContext(typeof(RecruitDbContext))]
    [Migration("20200328164824_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RecruitR.Domain.Projects.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsRecruiting")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("RecruitR.Domain.Projects.Project", b =>
                {
                    b.OwnsMany("RecruitR.Domain.Projects.ValueObjects.Link", "_links", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<Guid>("ProjectId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Url")
                                .HasColumnType("text");

                            b1.HasKey("Id");

                            b1.HasIndex("ProjectId");

                            b1.ToTable("Link");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.OwnsMany("RecruitR.Domain.Projects.ValueObjects.Technology", "_technologies", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<Guid>("ProjectId")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("ProjectId");

                            b1.ToTable("Technology");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}