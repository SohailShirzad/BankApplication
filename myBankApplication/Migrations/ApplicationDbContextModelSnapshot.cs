﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myBankApplication.Data;

#nullable disable

namespace myBankApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("myBankApplication.Models.AccountModel", b =>
                {
                    b.Property<int>("AccountNo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountNo"));

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUsersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName1")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime?>("Close_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Opened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sort_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("AccountNo");

                    b.HasIndex("AppUsersId");

                    b.HasIndex("BankName1");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("myBankApplication.Models.AppUsersModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfBirth")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_Joined")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<long>("Income")
                        .HasColumnType("bigint");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Post_Code")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Profile_Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Proof_Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("myBankApplication.Models.BankCardModel", b =>
                {
                    b.Property<int>("cardNumber")
                        .HasColumnType("int");

                    b.Property<int>("CVVNumber")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("Account_Id")
                        .HasColumnType("int");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUsersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ContaclessLimit")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.HasKey("cardNumber", "CVVNumber");

                    b.HasIndex("AppUsersId");

                    b.ToTable("BankCards");
                });

            modelBuilder.Entity("myBankApplication.Models.BankModel", b =>
                {
                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUsersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Bank_Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime>("Year_Opened")
                        .HasColumnType("datetime2");

                    b.HasKey("BankName");

                    b.HasIndex("AppUsersId");

                    b.ToTable("Bank");
                });

            modelBuilder.Entity("myBankApplication.Models.StatementModel", b =>
                {
                    b.Property<int>("StatementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatementID"));

                    b.Property<int?>("AccountNo")
                        .HasColumnType("int");

                    b.Property<int>("AccountNo1")
                        .HasColumnType("int");

                    b.Property<string>("AppUsersModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("StatementDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StatementID");

                    b.HasIndex("AccountNo1");

                    b.HasIndex("AppUsersModelId");

                    b.ToTable("Statements");
                });

            modelBuilder.Entity("myBankApplication.Models.TransactionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNo")
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("AccountNo1")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("AppUsersModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("BeniciaryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("SWIFTCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountNo1");

                    b.HasIndex("AppUsersModelId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("myBankApplication.Models.AppUsersModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("myBankApplication.Models.AppUsersModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("myBankApplication.Models.AppUsersModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("myBankApplication.Models.AppUsersModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("myBankApplication.Models.AccountModel", b =>
                {
                    b.HasOne("myBankApplication.Models.AppUsersModel", "AppUsers")
                        .WithMany("Accounts")
                        .HasForeignKey("AppUsersId");

                    b.HasOne("myBankApplication.Models.BankModel", "Bank")
                        .WithMany()
                        .HasForeignKey("BankName1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUsers");

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("myBankApplication.Models.BankCardModel", b =>
                {
                    b.HasOne("myBankApplication.Models.AppUsersModel", "AppUsers")
                        .WithMany("BankCards")
                        .HasForeignKey("AppUsersId");

                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("myBankApplication.Models.BankModel", b =>
                {
                    b.HasOne("myBankApplication.Models.AppUsersModel", "AppUsers")
                        .WithMany("Banks")
                        .HasForeignKey("AppUsersId");

                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("myBankApplication.Models.StatementModel", b =>
                {
                    b.HasOne("myBankApplication.Models.AccountModel", "Account")
                        .WithMany()
                        .HasForeignKey("AccountNo1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("myBankApplication.Models.AppUsersModel", null)
                        .WithMany("Statements")
                        .HasForeignKey("AppUsersModelId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("myBankApplication.Models.TransactionModel", b =>
                {
                    b.HasOne("myBankApplication.Models.AccountModel", "Account")
                        .WithMany()
                        .HasForeignKey("AccountNo1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("myBankApplication.Models.AppUsersModel", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AppUsersModelId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("myBankApplication.Models.AppUsersModel", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("BankCards");

                    b.Navigation("Banks");

                    b.Navigation("Statements");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
