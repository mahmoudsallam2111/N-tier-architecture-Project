using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Code);
                    table.UniqueConstraint("AK_Governorates_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Centrals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    GovernorateCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centrals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Centrals_Governorates_GovernorateCode",
                        column: x => x.GovernorateCode,
                        principalTable: "Governorates",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancelFine = table.Column<double>(type: "float", nullable: false),
                    FineOfSuspensed = table.Column<double>(type: "float", nullable: false),
                    IsPossibleToRasieOrLower = table.Column<bool>(type: "bit", nullable: true),
                    NumOfOfferMonth = table.Column<int>(type: "int", nullable: false),
                    NumOfFreeMonth = table.Column<int>(type: "int", nullable: false),
                    Isfreefirst = table.Column<bool>(type: "bit", nullable: false),
                    IsTotalBill = table.Column<bool>(type: "bit", nullable: false),
                    IsPercentageDiscount = table.Column<bool>(type: "bit", nullable: false),
                    DiscoutAmout = table.Column<double>(type: "float", nullable: false),
                    HasRouter = table.Column<bool>(type: "bit", nullable: false),
                    RouterPrice = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    purchasePrice = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CentralProvider",
                columns: table => new
                {
                    CentralsId = table.Column<int>(type: "int", nullable: false),
                    ProvidersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentralProvider", x => new { x.CentralsId, x.ProvidersId });
                    table.ForeignKey(
                        name: "FK_CentralProvider_Centrals_CentralsId",
                        column: x => x.CentralsId,
                        principalTable: "Centrals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CentralProvider_Providers_ProvidersId",
                        column: x => x.ProvidersId,
                        principalTable: "Providers",
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
                        name: "FK_AspNetUserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
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
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClientSSn = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fax = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Mobile1 = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Mobile2 = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    GovernorateCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Governorates_GovernorateCode",
                        column: x => x.GovernorateCode,
                        principalTable: "Governorates",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    SSn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Isactive = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernarateCode = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    CentralId = table.Column<int>(type: "int", nullable: false),
                    IpPackage = table.Column<int>(type: "int", nullable: true),
                    Contractdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mobile1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mobile2 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LineOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RouterSerial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortSlot = table.Column<int>(type: "int", nullable: true),
                    PortBlock = table.Column<int>(type: "int", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VPI = table.Column<int>(type: "int", nullable: true),
                    VCI = table.Column<int>(type: "int", nullable: true),
                    OrderWorkNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orderworkdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrePaid = table.Column<float>(type: "real", nullable: false),
                    installationFee = table.Column<float>(type: "real", nullable: false),
                    ContractFee = table.Column<float>(type: "real", nullable: false),
                    Slotnum = table.Column<int>(type: "int", nullable: true),
                    Blocknum = table.Column<int>(type: "int", nullable: true),
                    DisstrubtorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.SSn);
                    table.ForeignKey(
                        name: "FK_Clients_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Clients_Centrals_CentralId",
                        column: x => x.CentralId,
                        principalTable: "Centrals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Clients_Governorates_GovernarateCode",
                        column: x => x.GovernarateCode,
                        principalTable: "Governorates",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Clients_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Clients_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Clients_User_DisstrubtorId",
                        column: x => x.DisstrubtorId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
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
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientOffers",
                columns: table => new
                {
                    ClientSSn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    MonthsLeft = table.Column<int>(type: "int", nullable: false),
                    FreeMonthsLeft = table.Column<int>(type: "int", nullable: false),
                    RouterPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOffers", x => new { x.ClientSSn, x.OfferId });
                    table.ForeignKey(
                        name: "FK_ClientOffers_Clients_ClientSSn",
                        column: x => x.ClientSSn,
                        principalTable: "Clients",
                        principalColumn: "SSn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientOffers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Governorates",
                columns: new[] { "Code", "Name", "Status" },
                values: new object[] { 66, "cairo", true });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "Status" },
                values: new object[] { "1", null, "Role", "SuperAdmin", "SUPERADMIN", true });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "BranchId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, null, "0822972c-1dea-4ed0-9ffa-9b782504b89e", "reematman15@gmail.com", true, false, null, null, "REEM", "AQAAAAIAAYagAAAAEEdiocrQ0YxmgnvKqUiZc0LWBt3JicuVrpelh8Pc/yrdEbEmhwntgxkBTuZUlOw5jg==", null, false, "2f9458fd-7fe8-4e4c-a4d6-885a87408727", true, false, "Reem" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "RoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "Discriminator", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permission", "Permission.Bill.View", "RoleClaims<string>", "1" },
                    { 2, "Permission", "Permission.Bill.Create", "RoleClaims<string>", "1" },
                    { 3, "Permission", "Permission.Bill.Edit", "RoleClaims<string>", "1" },
                    { 4, "Permission", "Permission.Bill.Delete", "RoleClaims<string>", "1" },
                    { 5, "Permission", "Permission.Branch.View", "RoleClaims<string>", "1" },
                    { 6, "Permission", "Permission.Branch.Create", "RoleClaims<string>", "1" },
                    { 7, "Permission", "Permission.Branch.Edit", "RoleClaims<string>", "1" },
                    { 8, "Permission", "Permission.Branch.Delete", "RoleClaims<string>", "1" },
                    { 9, "Permission", "Permission.Central.View", "RoleClaims<string>", "1" },
                    { 10, "Permission", "Permission.Central.Create", "RoleClaims<string>", "1" },
                    { 11, "Permission", "Permission.Central.Edit", "RoleClaims<string>", "1" },
                    { 12, "Permission", "Permission.Central.Delete", "RoleClaims<string>", "1" },
                    { 13, "Permission", "Permission.Client.View", "RoleClaims<string>", "1" },
                    { 14, "Permission", "Permission.Client.Create", "RoleClaims<string>", "1" },
                    { 15, "Permission", "Permission.Client.Edit", "RoleClaims<string>", "1" },
                    { 16, "Permission", "Permission.Client.Delete", "RoleClaims<string>", "1" },
                    { 17, "Permission", "Permission.Governorate.View", "RoleClaims<string>", "1" },
                    { 18, "Permission", "Permission.Governorate.Create", "RoleClaims<string>", "1" },
                    { 19, "Permission", "Permission.Governorate.Edit", "RoleClaims<string>", "1" },
                    { 20, "Permission", "Permission.Governorate.Delete", "RoleClaims<string>", "1" },
                    { 21, "Permission", "Permission.Offer.View", "RoleClaims<string>", "1" },
                    { 22, "Permission", "Permission.Offer.Create", "RoleClaims<string>", "1" },
                    { 23, "Permission", "Permission.Offer.Edit", "RoleClaims<string>", "1" },
                    { 24, "Permission", "Permission.Offer.Delete", "RoleClaims<string>", "1" },
                    { 25, "Permission", "Permission.Package.View", "RoleClaims<string>", "1" },
                    { 26, "Permission", "Permission.Package.Create", "RoleClaims<string>", "1" },
                    { 27, "Permission", "Permission.Package.Edit", "RoleClaims<string>", "1" },
                    { 28, "Permission", "Permission.Package.Delete", "RoleClaims<string>", "1" },
                    { 29, "Permission", "Permission.Provider.View", "RoleClaims<string>", "1" },
                    { 30, "Permission", "Permission.Provider.Create", "RoleClaims<string>", "1" },
                    { 31, "Permission", "Permission.Provider.Edit", "RoleClaims<string>", "1" },
                    { 32, "Permission", "Permission.Provider.Delete", "RoleClaims<string>", "1" },
                    { 33, "Permission", "Permission.Role.View", "RoleClaims<string>", "1" },
                    { 34, "Permission", "Permission.Role.Create", "RoleClaims<string>", "1" },
                    { 35, "Permission", "Permission.Role.Edit", "RoleClaims<string>", "1" },
                    { 36, "Permission", "Permission.Role.Delete", "RoleClaims<string>", "1" },
                    { 37, "Permission", "Permission.User.View", "RoleClaims<string>", "1" },
                    { 38, "Permission", "Permission.User.Create", "RoleClaims<string>", "1" },
                    { 39, "Permission", "Permission.User.Edit", "RoleClaims<string>", "1" },
                    { 40, "Permission", "Permission.User.Delete", "RoleClaims<string>", "1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ClientSSn",
                table: "Bills",
                column: "ClientSSn");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserId",
                table: "Bills",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_GovernorateCode",
                table: "Branches",
                column: "GovernorateCode");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ManagerId",
                table: "Branches",
                column: "ManagerId",
                unique: true,
                filter: "[ManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Mobile1_Mobile2",
                table: "Branches",
                columns: new[] { "Mobile1", "Mobile2" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Phone1_Phone2",
                table: "Branches",
                columns: new[] { "Phone1", "Phone2" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CentralProvider_ProvidersId",
                table: "CentralProvider",
                column: "ProvidersId");

            migrationBuilder.CreateIndex(
                name: "IX_Centrals_GovernorateCode",
                table: "Centrals",
                column: "GovernorateCode");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOffers_ClientSSn",
                table: "ClientOffers",
                column: "ClientSSn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientOffers_OfferId",
                table: "ClientOffers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BranchId",
                table: "Clients",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CentralId",
                table: "Clients",
                column: "CentralId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DisstrubtorId",
                table: "Clients",
                column: "DisstrubtorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_GovernarateCode",
                table: "Clients",
                column: "GovernarateCode");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Mobile1_Mobile2",
                table: "Clients",
                columns: new[] { "Mobile1", "Mobile2" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_PackageId",
                table: "Clients",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Phone",
                table: "Clients",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ProviderId",
                table: "Clients",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ProviderId",
                table: "Offers",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ProviderId",
                table: "Packages",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_User_BranchId",
                table: "User",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_User_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_User_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_User_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Clients_ClientSSn",
                table: "Bills",
                column: "ClientSSn",
                principalTable: "Clients",
                principalColumn: "SSn");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_User_UserId",
                table: "Bills",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_User_ManagerId",
                table: "Branches",
                column: "ManagerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_User_ManagerId",
                table: "Branches");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "CentralProvider");

            migrationBuilder.DropTable(
                name: "ClientOffers");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Centrals");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Governorates");
        }
    }
}
