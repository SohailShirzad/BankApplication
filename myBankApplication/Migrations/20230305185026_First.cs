using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myBankApplication.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
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
                    Gender = table.Column<int>(type: "int", nullable: false),
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
                    ProofId = table.Column<byte[]>(name: "Proof_Id", type: "varbinary(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
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
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    Income = table.Column<long>(type: "bigint", nullable: false),
                    CountryOfBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostCode = table.Column<string>(name: "Post_Code", type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Supervisor = table.Column<int>(type: "int", nullable: false),
                    ManagerEmployeeId = table.Column<int>(name: "ManagerEmployee_Id", type: "int", nullable: true),
                    DateJoined = table.Column<DateTime>(name: "Date_Joined", type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankingPassword = table.Column<string>(name: "Banking_Password", type: "nvarchar(80)", maxLength: 80, nullable: false),
                    BankingConfirmationPassword = table.Column<string>(name: "Banking_ConfirmationPassword", type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Staff_Staff_ManagerEmployee_Id",
                        column: x => x.ManagerEmployeeId,
                        principalTable: "Staff",
                        principalColumn: "Employee_Id");
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    cardNumber = table.Column<int>(type: "int", nullable: false),
                    CVVNumber = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContaclessLimit = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(name: "Account_Id", type: "int", nullable: false),
                    CustomerId = table.Column<int>(name: "Customer_Id", type: "int", nullable: false),
                    CustomerId1 = table.Column<int>(name: "Customer_Id1", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => new { x.cardNumber, x.CVVNumber });
                    table.ForeignKey(
                        name: "FK_BankCards_Customers_Customer_Id1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    BankName = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    BankAddress = table.Column<string>(name: "Bank_Address", type: "nvarchar(80)", nullable: false),
                    YearOpened = table.Column<DateTime>(name: "Year_Opened", type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(name: "Employee_Id", type: "int", nullable: false),
                    ManagerEmployeeId = table.Column<int>(name: "ManagerEmployee_Id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BankName);
                    table.ForeignKey(
                        name: "FK_Bank_Staff_ManagerEmployee_Id",
                        column: x => x.ManagerEmployeeId,
                        principalTable: "Staff",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNo = table.Column<int>(type: "int", maxLength: 8, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortCode = table.Column<string>(name: "Sort_Code", type: "nvarchar(8)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    DateOpened = table.Column<DateTime>(name: "Date_Opened", type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CloseDate = table.Column<DateTime>(name: "Close_Date", type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(name: "Customer_Id", type: "int", maxLength: 8, nullable: false),
                    CustomerId1 = table.Column<int>(name: "Customer_Id1", type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName1 = table.Column<string>(type: "nvarchar(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNo);
                    table.ForeignKey(
                        name: "FK_Accounts_Bank_BankName1",
                        column: x => x.BankName1,
                        principalTable: "Bank",
                        principalColumn: "BankName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_Customer_Id1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    StatementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    AccountNo1 = table.Column<int>(type: "int", nullable: false),
                    StatementDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.StatementID);
                    table.ForeignKey(
                        name: "FK_Statements_Accounts_AccountNo1",
                        column: x => x.AccountNo1,
                        principalTable: "Accounts",
                        principalColumn: "AccountNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    AccountNo1 = table.Column<int>(type: "int", nullable: false),
                    BeniciaryName = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SWIFTCode = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountNo1",
                        column: x => x.AccountNo1,
                        principalTable: "Accounts",
                        principalColumn: "AccountNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BankName1",
                table: "Accounts",
                column: "BankName1");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Customer_Id1",
                table: "Accounts",
                column: "Customer_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_ManagerEmployee_Id",
                table: "Bank",
                column: "ManagerEmployee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_Customer_Id1",
                table: "BankCards",
                column: "Customer_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_ManagerEmployee_Id",
                table: "Staff",
                column: "ManagerEmployee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_AccountNo1",
                table: "Statements",
                column: "AccountNo1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountNo1",
                table: "Transactions",
                column: "AccountNo1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
