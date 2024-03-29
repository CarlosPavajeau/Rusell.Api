﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Rusell.BankDrafts.Shared.Infrastructure.Persistence.EntityFramework;

#nullable disable

namespace Rusell.BankDrafts.Migrations
{
    [DbContext(typeof(BankDraftsDbContext))]
    [Migration("20220122020054_FixCostName")]
    partial class FixCostName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Rusell.BankDrafts.Clients.Domain.Client", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.HasKey("Id")
                        .HasName("pk_clients");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("Rusell.BankDrafts.Companies.Domain.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.HasKey("Id")
                        .HasName("pk_companies");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("Rusell.BankDrafts.Domain.BankDraft", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<string>("DispatcherId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("dispatcher_id");

                    b.Property<string>("ReceiverId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("receiver_id");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sender_id");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("state");

                    b.HasKey("Id")
                        .HasName("pk_bank_drafts");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("ix_bank_drafts_company_id");

                    b.HasIndex("DispatcherId")
                        .HasDatabaseName("ix_bank_drafts_dispatcher_id");

                    b.HasIndex("ReceiverId")
                        .HasDatabaseName("ix_bank_drafts_receiver_id");

                    b.HasIndex("SenderId")
                        .HasDatabaseName("ix_bank_drafts_sender_id");

                    b.ToTable("bank_drafts", (string)null);
                });

            modelBuilder.Entity("Rusell.BankDrafts.Employees.Domain.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.HasKey("Id")
                        .HasName("pk_employees");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("Rusell.BankDrafts.Clients.Domain.Client", b =>
                {
                    b.OwnsOne("Rusell.BankDrafts.Clients.Domain.ClientName", "FullName", b1 =>
                        {
                            b1.Property<string>("ClientId")
                                .HasColumnType("text")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("full_name");

                            b1.HasKey("ClientId");

                            b1.ToTable("clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientId")
                                .HasConstraintName("fk_clients_clients_id");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("Rusell.BankDrafts.Companies.Domain.Company", b =>
                {
                    b.OwnsOne("Rusell.BankDrafts.Companies.Domain.CompanyName", "Name", b1 =>
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

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Rusell.BankDrafts.Domain.BankDraft", b =>
                {
                    b.HasOne("Rusell.BankDrafts.Companies.Domain.Company", "Company")
                        .WithMany("BankDrafts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bank_drafts_companies_company_temp_id");

                    b.HasOne("Rusell.BankDrafts.Employees.Domain.Employee", "Dispatcher")
                        .WithMany("BankDrafts")
                        .HasForeignKey("DispatcherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bank_drafts_employees_dispatcher_temp_id");

                    b.HasOne("Rusell.BankDrafts.Clients.Domain.Client", "Receiver")
                        .WithMany("BankDraftsReceived")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bank_drafts_clients_receiver_temp_id1");

                    b.HasOne("Rusell.BankDrafts.Clients.Domain.Client", "Sender")
                        .WithMany("BankDraftsSent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bank_drafts_clients_sender_temp_id");

                    b.OwnsOne("Rusell.BankDrafts.Domain.BankDraftAmount", "Amount", b1 =>
                        {
                            b1.Property<Guid>("BankDraftId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Value")
                                .HasColumnType("numeric")
                                .HasColumnName("amount");

                            b1.HasKey("BankDraftId");

                            b1.ToTable("bank_drafts");

                            b1.WithOwner()
                                .HasForeignKey("BankDraftId")
                                .HasConstraintName("fk_bank_drafts_bank_drafts_id");
                        });

                    b.OwnsOne("Rusell.BankDrafts.Domain.BankDraftCost", "Cost", b1 =>
                        {
                            b1.Property<Guid>("BankDraftId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Value")
                                .HasColumnType("numeric")
                                .HasColumnName("cost");

                            b1.HasKey("BankDraftId");

                            b1.ToTable("bank_drafts");

                            b1.WithOwner()
                                .HasForeignKey("BankDraftId")
                                .HasConstraintName("fk_bank_drafts_bank_drafts_id");
                        });

                    b.OwnsOne("Rusell.BankDrafts.Domain.BankDraftDate", "Date", b1 =>
                        {
                            b1.Property<Guid>("BankDraftId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateTime>("Value")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("date");

                            b1.HasKey("BankDraftId");

                            b1.ToTable("bank_drafts");

                            b1.WithOwner()
                                .HasForeignKey("BankDraftId")
                                .HasConstraintName("fk_bank_drafts_bank_drafts_id");
                        });

                    b.OwnsOne("Rusell.BankDrafts.Domain.BankDraftTotal", "Total", b1 =>
                        {
                            b1.Property<Guid>("BankDraftId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Value")
                                .HasColumnType("numeric")
                                .HasColumnName("total");

                            b1.HasKey("BankDraftId");

                            b1.ToTable("bank_drafts");

                            b1.WithOwner()
                                .HasForeignKey("BankDraftId")
                                .HasConstraintName("fk_bank_drafts_bank_drafts_id");
                        });

                    b.Navigation("Amount")
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Cost")
                        .IsRequired();

                    b.Navigation("Date")
                        .IsRequired();

                    b.Navigation("Dispatcher");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");

                    b.Navigation("Total")
                        .IsRequired();
                });

            modelBuilder.Entity("Rusell.BankDrafts.Employees.Domain.Employee", b =>
                {
                    b.OwnsOne("Rusell.BankDrafts.Employees.Domain.EmployeeName", "FullName", b1 =>
                        {
                            b1.Property<string>("EmployeeId")
                                .HasColumnType("text")
                                .HasColumnName("id");

                            b1.Property<string>("Value")
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("full_name");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId")
                                .HasConstraintName("fk_employees_employees_id");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("Rusell.BankDrafts.Clients.Domain.Client", b =>
                {
                    b.Navigation("BankDraftsReceived");

                    b.Navigation("BankDraftsSent");
                });

            modelBuilder.Entity("Rusell.BankDrafts.Companies.Domain.Company", b =>
                {
                    b.Navigation("BankDrafts");
                });

            modelBuilder.Entity("Rusell.BankDrafts.Employees.Domain.Employee", b =>
                {
                    b.Navigation("BankDrafts");
                });
#pragma warning restore 612, 618
        }
    }
}
