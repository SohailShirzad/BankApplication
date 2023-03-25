using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myBankApplication.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    BankName = table.Column<string>(type: "nvarchar(80)", nullable: false),
                    BankAddress = table.Column<string>(name: "Bank_Address", type: "nvarchar(80)", nullable: false),
                    YearOpened = table.Column<DateTime>(name: "Year_Opened", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BankName);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Education = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Income = table.Column<long>(type: "bigint", nullable: false),
                    CountryOfBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostCode = table.Column<string>(name: "Post_Code", type: "nvarchar(8)", maxLength: 8, nullable: false),
                    DateJoined = table.Column<DateTime>(name: "Date_Joined", type: "datetime2", nullable: false),
                    ProfilePicture = table.Column<string>(name: "Profile_Picture", type: "nvarchar(max)", nullable: true),
                    ProofId = table.Column<string>(name: "Proof_Id", type: "nvarchar(max)", nullable: true),
                    BankModelBankName = table.Column<string>(type: "nvarchar(80)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Bank_BankModelBankName",
                        column: x => x.BankModelBankName,
                        principalTable: "Bank",
                        principalColumn: "BankName");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortCode = table.Column<string>(name: "Sort_Code", type: "nvarchar(8)", nullable: true, defaultValue: "70493"),
                    AccountType = table.Column<string>(type: "nvarchar(8)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: true),
                    DateOpened = table.Column<DateTime>(name: "Date_Opened", type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CloseDate = table.Column<DateTime>(name: "Close_Date", type: "datetime2", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BankModelBankName = table.Column<string>(type: "nvarchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNo);
                    table.ForeignKey(
                        name: "FK_Accounts_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_Bank_BankModelBankName",
                        column: x => x.BankModelBankName,
                        principalTable: "Bank",
                        principalColumn: "BankName");
                });
            migrationBuilder.Sql("DBCC CHECKIDENT ('Accounts', RESEED, 12345678)");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CVVNumber = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContaclessLimit = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(name: "Account_Id", type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => new { x.CardNumber, x.CVVNumber });
                    table.ForeignKey(
                        name: "FK_BankCards_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

                


            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    StatementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<int>(type: "int", nullable: true),
                    AccountNo1 = table.Column<int>(type: "int", nullable: false),
                    StatementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUsersModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Statements_AspNetUsers_AppUsersModelId",
                        column: x => x.AppUsersModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<int>(type: "int", nullable: true),
                    AccountNo1 = table.Column<int>(type: "int", nullable: false),
                    BeniciaryName = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AppUsersModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_AppUsersModelId",
                        column: x => x.AppUsersModelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AppUsersId",
                table: "Accounts",
                column: "AppUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BankModelBankName",
                table: "Accounts",
                column: "BankModelBankName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BankModelBankName",
                table: "AspNetUsers",
                column: "BankModelBankName");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_AppUsersId",
                table: "BankCards",
                column: "AppUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_AccountNo1",
                table: "Statements",
                column: "AccountNo1");

            migrationBuilder.CreateIndex(
                name: "IX_Statements_AppUsersModelId",
                table: "Statements",
                column: "AppUsersModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountNo1",
                table: "Transactions",
                column: "AccountNo1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AppUsersModelId",
                table: "Transactions",
                column: "AppUsersModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bank");
        }
    }
}
