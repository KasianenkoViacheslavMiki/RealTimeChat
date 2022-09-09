using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reenbit.TestTask.RealTimeChat.Migrations
{
    public partial class Auto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId1",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Rooms_RoomId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_AspNetUsers_UserId1",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Rooms_RoomId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_UserId1",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId1",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Participant",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Participant",
                newName: "roomId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_RoomId",
                table: "Participant",
                newName: "IX_Participant_roomId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Message",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Message",
                newName: "roomId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_RoomId",
                table: "Message",
                newName: "IX_Message_roomId");

            migrationBuilder.AlterColumn<string>(
                name: "RoomName",
                table: "Room",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Participant",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Message",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TextMessage",
                table: "Message",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateMessage",
                table: "Message",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_userId",
                table: "Participant",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_userId",
                table: "Message",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Room",
                table: "Message",
                column: "roomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User",
                table: "Message",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Room",
                table: "Participant",
                column: "roomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_User",
                table: "Participant",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Room",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Room",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_User",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant");

            migrationBuilder.DropIndex(
                name: "IX_Participant_userId",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_userId",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Participants",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "Participants",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_roomId",
                table: "Participants",
                newName: "IX_Participants_RoomId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Messages",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "Messages",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_roomId",
                table: "Messages",
                newName: "IX_Messages_RoomId");

            migrationBuilder.AlterColumn<string>(
                name: "RoomName",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Participants",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Participants",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TextMessage",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateMessage",
                table: "Messages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_UserId1",
                table: "Participants",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId1",
                table: "Messages",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId1",
                table: "Messages",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Rooms_RoomId",
                table: "Messages",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_AspNetUsers_UserId1",
                table: "Participants",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Rooms_RoomId",
                table: "Participants",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
