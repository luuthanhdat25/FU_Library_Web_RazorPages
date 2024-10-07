using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FU_Library_Web.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnuseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Books_BookID",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_RequestStatuses_RequestStatusID",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Students_StudentID",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Campuses_CampusID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Librarians");

            migrationBuilder.DropTable(
                name: "NewsCategories");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypeID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_News_NewsCategoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_StudentID",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "UserTypeID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NewsCategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "BorrowBooks");

            migrationBuilder.RenameColumn(
                name: "CampusID",
                table: "Users",
                newName: "CampusId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CampusID",
                table: "Users",
                newName: "IX_Users_CampusId");

            migrationBuilder.RenameColumn(
                name: "RequestStatusID",
                table: "RequestStatuses",
                newName: "RequestStatusId");

            migrationBuilder.RenameColumn(
                name: "NewsID",
                table: "News",
                newName: "NewsId");

            migrationBuilder.RenameColumn(
                name: "ChatRoomID",
                table: "Messages",
                newName: "ChatRoomId");

            migrationBuilder.RenameColumn(
                name: "MessageID",
                table: "Messages",
                newName: "MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatRoomID",
                table: "Messages",
                newName: "IX_Messages_ChatRoomId");

            migrationBuilder.RenameColumn(
                name: "ChatRoomID",
                table: "ChatRooms",
                newName: "ChatRoomId");

            migrationBuilder.RenameColumn(
                name: "CampusID",
                table: "Campuses",
                newName: "CampusId");

            migrationBuilder.RenameColumn(
                name: "RequestStatusID",
                table: "BorrowBooks",
                newName: "RequestStatusId");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "BorrowBooks",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "BorrowBookID",
                table: "BorrowBooks",
                newName: "BorrowBookId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowBooks_RequestStatusID",
                table: "BorrowBooks",
                newName: "IX_BorrowBooks_RequestStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowBooks_BookID",
                table: "BorrowBooks",
                newName: "IX_BorrowBooks_BookId");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Books",
                newName: "BookId");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BorrowBooks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_UserId",
                table: "BorrowBooks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Books_BookId",
                table: "BorrowBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_RequestStatuses_RequestStatusId",
                table: "BorrowBooks",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "RequestStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Users_UserId",
                table: "BorrowBooks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "ChatRoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Campuses_CampusId",
                table: "Users",
                column: "CampusId",
                principalTable: "Campuses",
                principalColumn: "CampusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Books_BookId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_RequestStatuses_RequestStatusId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Users_UserId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Campuses_CampusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_BorrowBooks_UserId",
                table: "BorrowBooks");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BorrowBooks");

            migrationBuilder.RenameColumn(
                name: "CampusId",
                table: "Users",
                newName: "CampusID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CampusId",
                table: "Users",
                newName: "IX_Users_CampusID");

            migrationBuilder.RenameColumn(
                name: "RequestStatusId",
                table: "RequestStatuses",
                newName: "RequestStatusID");

            migrationBuilder.RenameColumn(
                name: "NewsId",
                table: "News",
                newName: "NewsID");

            migrationBuilder.RenameColumn(
                name: "ChatRoomId",
                table: "Messages",
                newName: "ChatRoomID");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "Messages",
                newName: "MessageID");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChatRoomId",
                table: "Messages",
                newName: "IX_Messages_ChatRoomID");

            migrationBuilder.RenameColumn(
                name: "ChatRoomId",
                table: "ChatRooms",
                newName: "ChatRoomID");

            migrationBuilder.RenameColumn(
                name: "CampusId",
                table: "Campuses",
                newName: "CampusID");

            migrationBuilder.RenameColumn(
                name: "RequestStatusId",
                table: "BorrowBooks",
                newName: "RequestStatusID");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BorrowBooks",
                newName: "BookID");

            migrationBuilder.RenameColumn(
                name: "BorrowBookId",
                table: "BorrowBooks",
                newName: "BorrowBookID");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowBooks_RequestStatusId",
                table: "BorrowBooks",
                newName: "IX_BorrowBooks_RequestStatusID");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowBooks_BookId",
                table: "BorrowBooks",
                newName: "IX_BorrowBooks_BookID");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "BookID");

            migrationBuilder.AddColumn<Guid>(
                name: "UserTypeID",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "NewsCategoryId",
                table: "News",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "StudentID",
                table: "BorrowBooks",
                type: "nvarchar(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Librarians",
                columns: table => new
                {
                    LibrarianID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarians", x => x.LibrarianID);
                    table.ForeignKey(
                        name: "FK_Librarians_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    NewsCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => x.NewsCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateProvide = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                column: "UserTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsCategoryId",
                table: "News",
                column: "NewsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowBooks_StudentID",
                table: "BorrowBooks",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Librarians_UserID",
                table: "Librarians",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserID",
                table: "Students",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Books_BookID",
                table: "BorrowBooks",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_RequestStatuses_RequestStatusID",
                table: "BorrowBooks",
                column: "RequestStatusID",
                principalTable: "RequestStatuses",
                principalColumn: "RequestStatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Students_StudentID",
                table: "BorrowBooks",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatRooms_ChatRoomID",
                table: "Messages",
                column: "ChatRoomID",
                principalTable: "ChatRooms",
                principalColumn: "ChatRoomID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_NewsCategories_NewsCategoryId",
                table: "News",
                column: "NewsCategoryId",
                principalTable: "NewsCategories",
                principalColumn: "NewsCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Campuses_CampusID",
                table: "Users",
                column: "CampusID",
                principalTable: "Campuses",
                principalColumn: "CampusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeID",
                table: "Users",
                column: "UserTypeID",
                principalTable: "UserTypes",
                principalColumn: "UserTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
