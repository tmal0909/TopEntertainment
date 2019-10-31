using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopEntertainment.Database.Migrations
{
    public partial class transactionreacord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferRecords_Members_GiverId",
                table: "TransferRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferRecords_Administrators_OperatorID",
                table: "TransferRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferRecords_Members_ReceiverId",
                table: "TransferRecords");

            migrationBuilder.DropIndex(
                name: "IX_TransferRecords_GiverId",
                table: "TransferRecords");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "TransferRecords");

            migrationBuilder.DropColumn(
                name: "GiverId",
                table: "TransferRecords");

            migrationBuilder.RenameColumn(
                name: "OperatorID",
                table: "TransferRecords",
                newName: "OperatorId");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "TransferRecords",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_TransferRecords_OperatorID",
                table: "TransferRecords",
                newName: "IX_TransferRecords_OperatorId");

            migrationBuilder.RenameIndex(
                name: "IX_TransferRecords_ReceiverId",
                table: "TransferRecords",
                newName: "IX_TransferRecords_MemberId");

            migrationBuilder.AddColumn<decimal>(
                name: "Integration",
                table: "TransferRecords",
                type: "decimal(12,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "TransferRecords",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_TransferRecords_Members_MemberId",
                table: "TransferRecords",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferRecords_Administrators_OperatorId",
                table: "TransferRecords",
                column: "OperatorId",
                principalTable: "Administrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferRecords_Members_MemberId",
                table: "TransferRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferRecords_Administrators_OperatorId",
                table: "TransferRecords");

            migrationBuilder.DropColumn(
                name: "Integration",
                table: "TransferRecords");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "TransferRecords");

            migrationBuilder.RenameColumn(
                name: "OperatorId",
                table: "TransferRecords",
                newName: "OperatorID");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "TransferRecords",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_TransferRecords_OperatorId",
                table: "TransferRecords",
                newName: "IX_TransferRecords_OperatorID");

            migrationBuilder.RenameIndex(
                name: "IX_TransferRecords_MemberId",
                table: "TransferRecords",
                newName: "IX_TransferRecords_ReceiverId");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "TransferRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GiverId",
                table: "TransferRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_TransferRecords_GiverId",
                table: "TransferRecords",
                column: "GiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferRecords_Members_GiverId",
                table: "TransferRecords",
                column: "GiverId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferRecords_Administrators_OperatorID",
                table: "TransferRecords",
                column: "OperatorID",
                principalTable: "Administrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferRecords_Members_ReceiverId",
                table: "TransferRecords",
                column: "ReceiverId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
