using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopEntertainment.Database.Migrations
{
    public partial class initialize1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministratorEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Identity = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Role = table.Column<short>(type: "smallint", nullable: false),
                    UtcUpdateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministratorEntity", x => x.Id);
                    table.UniqueConstraint("AK_AdministratorEntity_Identity", x => x.Identity);
                });

            migrationBuilder.CreateTable(
                name: "MemberEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Identity = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Role = table.Column<short>(type: "smallint", nullable: false),
                    UtcUpdateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberEntity", x => x.Id);
                    table.UniqueConstraint("AK_MemberEntity_Identity", x => x.Identity);
                });

            migrationBuilder.CreateTable(
                name: "TransferRecordEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionId = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    GiverId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    OperatorID = table.Column<int>(type: "int", nullable: false),
                    UtcUpdateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferRecordEntity", x => x.Id);
                    table.UniqueConstraint("AK_TransferRecordEntity_TransactionId", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransferRecordEntity_MemberEntity_GiverId",
                        column: x => x.GiverId,
                        principalTable: "MemberEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferRecordEntity_AdministratorEntity_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "AdministratorEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferRecordEntity_MemberEntity_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "MemberEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AdministratorEntity",
                columns: new[] { "Id", "Account", "Address", "Birthday", "Identity", "Name", "Password", "Phone", "Role" },
                values: new object[] { 1, "Dev", "Default Address", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A123456789", "Developer", "Dev", "0912345678", (short)1 });

            migrationBuilder.CreateIndex(
                name: "IX_TransferRecordEntity_GiverId",
                table: "TransferRecordEntity",
                column: "GiverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRecordEntity_OperatorID",
                table: "TransferRecordEntity",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRecordEntity_ReceiverId",
                table: "TransferRecordEntity",
                column: "ReceiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferRecordEntity");

            migrationBuilder.DropTable(
                name: "MemberEntity");

            migrationBuilder.DropTable(
                name: "AdministratorEntity");
        }
    }
}
