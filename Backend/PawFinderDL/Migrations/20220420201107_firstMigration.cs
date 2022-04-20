using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawFinderDL.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserBio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserBreed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    LikerID = table.Column<int>(type: "int", nullable: false),
                    LikedID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Like_User_LikedID",
                        column: x => x.LikedID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Like_User_LikerID",
                        column: x => x.LikerID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    MatcherOneID = table.Column<int>(type: "int", nullable: false),
                    MatcherTwoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Match_User_MatcherOneID",
                        column: x => x.MatcherOneID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_User_MatcherTwoID",
                        column: x => x.MatcherTwoID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    messageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderID = table.Column<int>(type: "int", nullable: false),
                    ReceiverID = table.Column<int>(type: "int", nullable: false),
                    messageText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    messageTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.messageID);
                    table.ForeignKey(
                        name: "FK_Message_User_ReceiverID",
                        column: x => x.ReceiverID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message_User_SenderID",
                        column: x => x.SenderID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pass",
                columns: table => new
                {
                    PasserID = table.Column<int>(type: "int", nullable: false),
                    PasseeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Pass_User_PasseeID",
                        column: x => x.PasseeID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pass_User_PasserID",
                        column: x => x.PasserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    photoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.photoID);
                    table.ForeignKey(
                        name: "FK_Photo_User_userID",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Like_LikedID",
                table: "Like",
                column: "LikedID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_LikerID",
                table: "Like",
                column: "LikerID");

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatcherOneID",
                table: "Match",
                column: "MatcherOneID");

            migrationBuilder.CreateIndex(
                name: "IX_Match_MatcherTwoID",
                table: "Match",
                column: "MatcherTwoID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ReceiverID",
                table: "Message",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderID",
                table: "Message",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Pass_PasseeID",
                table: "Pass",
                column: "PasseeID");

            migrationBuilder.CreateIndex(
                name: "IX_Pass_PasserID",
                table: "Pass",
                column: "PasserID");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_userID",
                table: "Photo",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Pass");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
