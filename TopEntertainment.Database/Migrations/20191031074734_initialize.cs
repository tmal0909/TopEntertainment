using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopEntertainment.Database.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
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
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.UniqueConstraint("AK_Administrators_Identity", x => x.Identity);
                });

            migrationBuilder.CreateTable(
                name: "Members",
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
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.UniqueConstraint("AK_Members_Identity", x => x.Identity);
                });

            migrationBuilder.CreateTable(
                name: "TransferRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionId = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    GiverId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    OperatorID = table.Column<int>(type: "int", nullable: false),
                    UtcUpdateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferRecords", x => x.Id);
                    table.UniqueConstraint("AK_TransferRecords_TransactionId", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransferRecords_Members_GiverId",
                        column: x => x.GiverId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferRecords_Administrators_OperatorID",
                        column: x => x.OperatorID,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferRecords_Members_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "Account", "Address", "Birthday", "Identity", "Name", "Password", "Phone", "Role" },
                values: new object[] { 1, "Dev", "Default Address", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A123456789", "Developer", "Dev", "0912345678", (short)1 });

            migrationBuilder.CreateIndex(
                name: "IX_TransferRecords_GiverId",
                table: "TransferRecords",
                column: "GiverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRecords_OperatorID",
                table: "TransferRecords",
                column: "OperatorID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRecords_ReceiverId",
                table: "TransferRecords",
                column: "ReceiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferRecords");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Administrators");
        }
    }
}
