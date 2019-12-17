using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Insta.DataAccess.Migrations
{
    public partial class TheFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityTypeRecords",
                columns: table => new
                {
                    EntityTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityTypeRecords", x => x.EntityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UniqueTagRecords",
                columns: table => new
                {
                    UniqueTagId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniqueTagRecords", x => x.UniqueTagId);
                });

            migrationBuilder.CreateTable(
                name: "UserRecords",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    EncryptedPassword = table.Column<string>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecords", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "EntityRecords",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityGuid = table.Column<Guid>(nullable: false),
                    EntityTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityRecords", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_EntityRecords_EntityTypeRecords_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalTable: "EntityTypeRecords",
                        principalColumn: "EntityTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostRecords",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    Geolocation = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostRecords", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_PostRecords_UserRecords_UserId",
                        column: x => x.UserId,
                        principalTable: "UserRecords",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileRecords",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IsVisible = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileRecords", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ProfileRecords_UserRecords_UserId",
                        column: x => x.UserId,
                        principalTable: "UserRecords",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionRecords",
                columns: table => new
                {
                    SubscribedToUserId = table.Column<int>(nullable: false),
                    SubscriberUserId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionRecords", x => new { x.SubscriberUserId, x.SubscribedToUserId });
                    table.ForeignKey(
                        name: "FK_SubscriptionRecords_UserRecords_SubscribedToUserId",
                        column: x => x.SubscribedToUserId,
                        principalTable: "UserRecords",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_SubscriptionRecords_UserRecords_SubscriberUserId",
                        column: x => x.SubscriberUserId,
                        principalTable: "UserRecords",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "LikeRecords",
                columns: table => new
                {
                    LikeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    EntityId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeRecords", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_LikeRecords_EntityRecords_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityRecords",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeRecords_UserRecords_UserId",
                        column: x => x.UserId,
                        principalTable: "UserRecords",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotoRecords",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CloudUrl = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    EntityId = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoRecords", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_PhotoRecords_EntityRecords_EntityId",
                        column: x => x.EntityId,
                        principalTable: "EntityRecords",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentRecords",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    ParentCommentId = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRecords", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_CommentRecords_CommentRecords_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "CommentRecords",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentRecords_PostRecords_PostId",
                        column: x => x.PostId,
                        principalTable: "PostRecords",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentRecords_UserRecords_UserId",
                        column: x => x.UserId,
                        principalTable: "UserRecords",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "DescriptionRecords",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionRecords", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_DescriptionRecords_PostRecords_PostId",
                        column: x => x.PostId,
                        principalTable: "PostRecords",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagRecords",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    UniqueTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagRecords", x => new { x.PostId, x.UniqueTagId });
                    table.ForeignKey(
                        name: "FK_TagRecords_PostRecords_PostId",
                        column: x => x.PostId,
                        principalTable: "PostRecords",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagRecords_UniqueTagRecords_UniqueTagId",
                        column: x => x.UniqueTagId,
                        principalTable: "UniqueTagRecords",
                        principalColumn: "UniqueTagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentRecords_ParentCommentId",
                table: "CommentRecords",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRecords_PostId",
                table: "CommentRecords",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRecords_UserId",
                table: "CommentRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRecords_EntityTypeId",
                table: "EntityRecords",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeRecords_EntityId",
                table: "LikeRecords",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeRecords_UserId",
                table: "LikeRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoRecords_EntityId",
                table: "PhotoRecords",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PostRecords_UserId",
                table: "PostRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionRecords_SubscribedToUserId",
                table: "SubscriptionRecords",
                column: "SubscribedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TagRecords_UniqueTagId",
                table: "TagRecords",
                column: "UniqueTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentRecords");

            migrationBuilder.DropTable(
                name: "DescriptionRecords");

            migrationBuilder.DropTable(
                name: "LikeRecords");

            migrationBuilder.DropTable(
                name: "PhotoRecords");

            migrationBuilder.DropTable(
                name: "ProfileRecords");

            migrationBuilder.DropTable(
                name: "SubscriptionRecords");

            migrationBuilder.DropTable(
                name: "TagRecords");

            migrationBuilder.DropTable(
                name: "EntityRecords");

            migrationBuilder.DropTable(
                name: "PostRecords");

            migrationBuilder.DropTable(
                name: "UniqueTagRecords");

            migrationBuilder.DropTable(
                name: "EntityTypeRecords");

            migrationBuilder.DropTable(
                name: "UserRecords");
        }
    }
}
