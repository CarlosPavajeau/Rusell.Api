﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Rusell.Companies.Shared.Infrastructure.Persistence.EntityFramework;

#nullable disable

namespace Rusell.Companies.Migrations
{
    [DbContext(typeof(CompaniesDbContext))]
    [Migration("20211213233935_AddUserId")]
    partial class AddUserId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Rusell.Companies.Domain.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.HasKey("Id")
                        .HasName("pk_companies");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("Rusell.Companies.Domain.Company", b =>
                {
                    b.OwnsOne("Rusell.Companies.Domain.CompanyInfo", "Info", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("info");

                            b1.HasKey("CompanyId");

                            b1.ToTable("companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId")
                                .HasConstraintName("fk_companies_companies_id");
                        });

                    b.OwnsOne("Rusell.Companies.Domain.CompanyName", "Name", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("name");

                            b1.HasKey("CompanyId");

                            b1.ToTable("companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId")
                                .HasConstraintName("fk_companies_companies_id");
                        });

                    b.OwnsOne("Rusell.Companies.Domain.Nit", "Nit", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("nit");

                            b1.HasKey("CompanyId");

                            b1.HasIndex("Value")
                                .IsUnique()
                                .HasDatabaseName("ix_companies_nit");

                            b1.ToTable("companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId")
                                .HasConstraintName("fk_companies_companies_id");
                        });

                    b.OwnsOne("Rusell.Shared.Domain.UserId", "UserId", b1 =>
                        {
                            b1.Property<Guid>("CompanyId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("user_id");

                            b1.HasKey("CompanyId");

                            b1.HasIndex("Value")
                                .HasDatabaseName("ix_companies_user_id");

                            b1.ToTable("companies");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId")
                                .HasConstraintName("fk_companies_companies_id");
                        });

                    b.Navigation("Info")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Nit");

                    b.Navigation("UserId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
