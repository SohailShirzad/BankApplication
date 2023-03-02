using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myBankApplication.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(name: "Customer_Id", type: "int", maxLength: 8, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNo = table.Column<string>(name: "Phone_No", type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Education = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    Income = table.Column<long>(type: "bigint", maxLength: 50, nullable: false),
                    CountryOfBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostCode = table.Column<string>(name: "Post_Code", type: "nvarchar(8)", maxLength: 8, nullable: false),
                    DateJoined = table.Column<DateTime>(name: "Date_Joined", type: "datetime2", nullable: false),
                    BankingPassword = table.Column<string>(name: "Banking_Password", type: "nvarchar(80)", maxLength: 80, nullable: false),
                    BankingConfirmationPassword = table.Column<string>(name: "Banking_ConfirmationPassword", type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ProfilePicture = table.Column<byte[]>(name: "Profile_Picture", type: "varbinary(max)", nullable: false),
                    ProofId = table.Column<byte[]>(name: "Proof_Id", type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(name: "Employee_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNo = table.Column<string>(name: "Phone_No", type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Education = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Jobtitle = table.Column<string>(name: "Job_title", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    Income = table.Column<long>(type: "bigint", nullable: false),
                    CountryOfBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostCode = table.Column<string>(name: "Post_Code", type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Supervisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateJoined = table.Column<DateTime>(name: "Date_Joined", type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankingPassword = table.Column<string>(name: "Banking_Password", type: "nvarchar(80)", maxLength: 80, nullable: false),
                    BankingConfirmationPassword = table.Column<string>(name: "Banking_ConfirmationPassword", type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNo = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortCode = table.Column<string>(name: "Sort_Code", type: "nvarchar(8)", nullable: false),
                    AccountType = table.Column<string>(name: "Account_Type", type: "nvarchar(8)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    DateOpened = table.Column<DateTime>(name: "Date_Opened", type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(name: "Is_Active", type: "bit", nullable: false),
                    CloseDate = table.Column<DateTime>(name: "Close_Date", type: "datetime2", nullable: false),
                    CustomerId = table.Column<string>(name: "Customer_Id", type: "nvarchar(8)", maxLength: 8, nullable: false),
                    CustomerId1 = table.Column<int>(name: "Customer_Id1", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNo);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_Customer_Id1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    BankAddress = table.Column<string>(name: "Bank_Address", type: "nvarchar(80)", nullable: false),
                    YearOpened = table.Column<DateTime>(name: "Year_Opened", type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(name: "Customer_Id", type: "int", nullable: false),
                    ManagerCustomerId = table.Column<int>(name: "ManagerCustomer_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Bank_Customers_ManagerCustomer_Id",
                        column: x => x.ManagerCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<string>(name: "Account_No", type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AccountNo0 = table.Column<int>(name: "AccountNo", type: "int", nullable: false),
                    BeniciaryName = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SWIFTCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountNo",
                        column: x => x.AccountNo0,
                        principalTable: "Accounts",
                        principalColumn: "AccountNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Customer_Id1",
                table: "Accounts",
                column: "Customer_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_ManagerCustomer_Id",
                table: "Bank",
                column: "ManagerCustomer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountNo",
                table: "Transactions",
                column: "AccountNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
