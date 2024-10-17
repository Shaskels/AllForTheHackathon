﻿// <auto-generated />
using System;
using AllForTheHackathon.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AllForTheHackathon.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("AllForTheHackathon.Domain.Employees.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdInList")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("AllForTheHackathon.Domain.Hackathon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Result")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Hackathons");
                });

            modelBuilder.Entity("AllForTheHackathon.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HackathonId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JuniorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SatisfactionOfJunior")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SatisfactionOfTeamLeader")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeamLeaderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HackathonId");

                    b.HasIndex("JuniorId");

                    b.HasIndex("TeamLeaderId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("AllForTheHackathon.Domain.Wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("EmployeeWishlist", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WishlistsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmployeesId", "WishlistsId");

                    b.HasIndex("WishlistsId");

                    b.ToTable("dlsa;ld;a", (string)null);
                });

            modelBuilder.Entity("AllForTheHackathon.Domain.Employees.Junior", b =>
                {
                    b.HasBaseType("AllForTheHackathon.Domain.Employees.Employee");

                    b.Property<int?>("HackathonId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("HackathonId");

                    b.ToTable("Junior");
                });

            modelBuilder.Entity("AllForTheHackathon.Domain.Employees.TeamLead", b =>
                {
                    b.HasBaseType("AllForTheHackathon.Domain.Employees.Employee");

                    b.Property<int?>("HackathonId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("HackathonId");

                    b.ToTable("TeamLead");
                });

            modelBuilder.Entity("AllForTheHackathon.Domain.Team", b =>
                {
                    b.HasOne("AllForTheHackathon.Domain.Hackathon", "Hackathon")
                        .WithMany("Teams")
                        .HasForeignKey("HackathonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllForTheHackathon.Domain.Employees.Employee", "Junior")
                        .WithMany()
                        .HasForeignKey("JuniorId");

                    b.HasOne("AllForTheHackathon.Domain.Employees.Employee", "TeamLeader")
                        .WithMany()
                        .HasForeignKey("TeamLeaderId");

                    b.Navigation("Hackathon");

                    b.Navigation("Junior");

                    b.Navigation("TeamLeader");
                });

            modelBuilder.Entity("AllForTheHackathon.Domain.Wishlist", b =>
                {
                    b.HasOne("AllForTheHackathon.Domain.Employees.Employee", "Employee")
                        .WithOne("Wishlist")
                        .HasForeignKey("AllForTheHackathon.Domain.Wishlist", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeWishlist", b =>
                {
                    b.HasOne("AllForTheHackathon.Domain.Employees.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AllForTheHackathon.Domain.Wishlist", null)
                        .WithMany()
                        .HasForeignKey("WishlistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AllForTheHackathon.Domain.Employees.Junior", b =>
                {
                    b.HasOne("AllForTheHackathon.Domain.Hackathon", null)
                        .WithMany("Juniors")
                        .HasForeignKey("HackathonId");

                    b.HasOne("AllForTheHackathon.Domain.Employees.Employee", null)
                        .WithOne()
                        .HasForeignKey("AllForTheHackathon.Domain.Employees.Junior", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AllForTheHackathon.Domain.Employees.TeamLead", b =>
                {
                    b.HasOne("AllForTheHackathon.Domain.Hackathon", null)
                        .WithMany("TeamLeads")
                        .HasForeignKey("HackathonId");

                    b.HasOne("AllForTheHackathon.Domain.Employees.Employee", null)
                        .WithOne()
                        .HasForeignKey("AllForTheHackathon.Domain.Employees.TeamLead", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AllForTheHackathon.Domain.Employees.Employee", b =>
                {
                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("AllForTheHackathon.Domain.Hackathon", b =>
                {
                    b.Navigation("Juniors");

                    b.Navigation("TeamLeads");

                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
