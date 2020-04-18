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
    [Migration("20200411190353_CustomerAggregateRoot")]
    partial class CustomerAggregateRoot
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RecruitR.Domain.Customer.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("character varying(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

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

            modelBuilder.Entity("RecruitR.Domain.Customer.Customer", b =>
                {
                    b.OwnsMany("RecruitR.Domain.Customer.Entities.Education.Education", "_education", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Description")
                                .HasColumnType("text");

                            b1.Property<DateTime?>("Finish")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("timestamp without time zone");

                            b1.HasKey("Id");

                            b1.HasIndex("CustomerId");

                            b1.ToTable("Education");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsMany("RecruitR.Domain.Customer.Entities.Experience.Experience", "_experiences", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Description")
                                .HasColumnType("text");

                            b1.Property<DateTime?>("Finish")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("timestamp without time zone");

                            b1.HasKey("Id");

                            b1.HasIndex("CustomerId");

                            b1.ToTable("Experience");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsMany("RecruitR.Domain.Customer.Entities.Skills.Skill", "_skills", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Experience")
                                .HasColumnType("numeric");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<long>("Proficiency")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("CustomerId");

                            b1.ToTable("Skill");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("RecruitR.Domain.Customer.ValueObjects.PersonalInfo", "Info", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Description")
                                .HasColumnType("character varying(2000)")
                                .HasMaxLength(2000);

                            b1.Property<byte>("Gender")
                                .HasColumnType("smallint");

                            b1.Property<string>("Nationality")
                                .HasColumnType("character varying(200)")
                                .HasMaxLength(200);

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });
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
