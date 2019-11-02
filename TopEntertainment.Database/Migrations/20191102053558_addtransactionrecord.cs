using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopEntertainment.Database.Migrations
{
    public partial class addtransactionrecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferRecords");

            migrationBuilder.CreateTable(
                name: "TransactionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionId = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    Integration = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: false),
                    UtcUpdateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionRecords", x => x.Id);
                    table.UniqueConstraint("AK_TransactionRecords_TransactionId", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransactionRecords_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionRecords_Administrators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRecords_MemberId",
                table: "TransactionRecords",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionRecords_OperatorId",
                table: "TransactionRecords",
                column: "OperatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionRecords");

            migrationBuilder.CreateTable(
                name: "TransferRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Integration = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    OperatorId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    UtcUpdateTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferRecords", x => x.Id);
                    table.UniqueConstraint("AK_TransferRecords_TransactionId", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TransferRecords_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferRecords_Administrators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransferRecords_MemberId",
                table: "TransferRecords",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferRecords_OperatorId",
                table: "TransferRecords",
                column: "OperatorId");
        }
    }
}
