using Microsoft.EntityFrameworkCore.Migrations;

namespace Insta.DataAccess.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentRecords_CommentRecords_ParentCommentId",
                table: "CommentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRecords_PostRecords_PostId",
                table: "CommentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentRecords_UserRecords_UserId",
                table: "CommentRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionRecords_PostRecords_PostId",
                table: "DescriptionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_EntityRecords_EntityTypeRecords_EntityTypeId",
                table: "EntityRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeRecords_EntityRecords_EntityId",
                table: "LikeRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeRecords_UserRecords_UserId",
                table: "LikeRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoRecords_EntityRecords_EntityId",
                table: "PhotoRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_PostRecords_UserRecords_UserId",
                table: "PostRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileRecords_UserRecords_UserId",
                table: "ProfileRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionRecords_UserRecords_SubscribedToUserId",
                table: "SubscriptionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionRecords_UserRecords_SubscriberUserId",
                table: "SubscriptionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TagRecords_PostRecords_PostId",
                table: "TagRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TagRecords_UniqueTagRecords_UniqueTagId",
                table: "TagRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRecords",
                table: "UserRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UniqueTagRecords",
                table: "UniqueTagRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagRecords",
                table: "TagRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionRecords",
                table: "SubscriptionRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileRecords",
                table: "ProfileRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostRecords",
                table: "PostRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhotoRecords",
                table: "PhotoRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeRecords",
                table: "LikeRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityTypeRecords",
                table: "EntityTypeRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityRecords",
                table: "EntityRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DescriptionRecords",
                table: "DescriptionRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentRecords",
                table: "CommentRecords");

            migrationBuilder.RenameTable(
                name: "UserRecords",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UniqueTagRecords",
                newName: "UniqueTags");

            migrationBuilder.RenameTable(
                name: "TagRecords",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "SubscriptionRecords",
                newName: "Subscriptions");

            migrationBuilder.RenameTable(
                name: "ProfileRecords",
                newName: "Profiles");

            migrationBuilder.RenameTable(
                name: "PostRecords",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "PhotoRecords",
                newName: "Photos");

            migrationBuilder.RenameTable(
                name: "LikeRecords",
                newName: "Likes");

            migrationBuilder.RenameTable(
                name: "EntityTypeRecords",
                newName: "EntityTypes");

            migrationBuilder.RenameTable(
                name: "EntityRecords",
                newName: "Entities");

            migrationBuilder.RenameTable(
                name: "DescriptionRecords",
                newName: "Descriptions");

            migrationBuilder.RenameTable(
                name: "CommentRecords",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_TagRecords_UniqueTagId",
                table: "Tags",
                newName: "IX_Tags_UniqueTagId");

            migrationBuilder.RenameIndex(
                name: "IX_SubscriptionRecords_SubscribedToUserId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_SubscribedToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostRecords_UserId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoRecords_EntityId",
                table: "Photos",
                newName: "IX_Photos_EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeRecords_UserId",
                table: "Likes",
                newName: "IX_Likes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeRecords_EntityId",
                table: "Likes",
                newName: "IX_Likes_EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_EntityRecords_EntityTypeId",
                table: "Entities",
                newName: "IX_Entities_EntityTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentRecords_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentRecords_PostId",
                table: "Comments",
                newName: "IX_Comments_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentRecords_ParentCommentId",
                table: "Comments",
                newName: "IX_Comments_ParentCommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UniqueTags",
                table: "UniqueTags",
                column: "UniqueTagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                columns: new[] { "PostId", "UniqueTagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions",
                columns: new[] { "SubscriberUserId", "SubscribedToUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "PhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "LikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityTypes",
                table: "EntityTypes",
                column: "EntityTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Descriptions",
                table: "Descriptions",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_Posts_PostId",
                table: "Descriptions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_EntityTypes_EntityTypeId",
                table: "Entities",
                column: "EntityTypeId",
                principalTable: "EntityTypes",
                principalColumn: "EntityTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Entities_EntityId",
                table: "Likes",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Entities_EntityId",
                table: "Photos",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Users_SubscribedToUserId",
                table: "Subscriptions",
                column: "SubscribedToUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Users_SubscriberUserId",
                table: "Subscriptions",
                column: "SubscriberUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_UniqueTags_UniqueTagId",
                table: "Tags",
                column: "UniqueTagId",
                principalTable: "UniqueTags",
                principalColumn: "UniqueTagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_Posts_PostId",
                table: "Descriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Entities_EntityTypes_EntityTypeId",
                table: "Entities");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Entities_EntityId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Entities_EntityId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Users_SubscribedToUserId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Users_SubscriberUserId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_UniqueTags_UniqueTagId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UniqueTags",
                table: "UniqueTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriptions",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityTypes",
                table: "EntityTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Descriptions",
                table: "Descriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserRecords");

            migrationBuilder.RenameTable(
                name: "UniqueTags",
                newName: "UniqueTagRecords");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "TagRecords");

            migrationBuilder.RenameTable(
                name: "Subscriptions",
                newName: "SubscriptionRecords");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "ProfileRecords");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "PostRecords");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "PhotoRecords");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "LikeRecords");

            migrationBuilder.RenameTable(
                name: "EntityTypes",
                newName: "EntityTypeRecords");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "EntityRecords");

            migrationBuilder.RenameTable(
                name: "Descriptions",
                newName: "DescriptionRecords");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentRecords");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_UniqueTagId",
                table: "TagRecords",
                newName: "IX_TagRecords_UniqueTagId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_SubscribedToUserId",
                table: "SubscriptionRecords",
                newName: "IX_SubscriptionRecords_SubscribedToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "PostRecords",
                newName: "IX_PostRecords_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_EntityId",
                table: "PhotoRecords",
                newName: "IX_PhotoRecords_EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId",
                table: "LikeRecords",
                newName: "IX_LikeRecords_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_EntityId",
                table: "LikeRecords",
                newName: "IX_LikeRecords_EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Entities_EntityTypeId",
                table: "EntityRecords",
                newName: "IX_EntityRecords_EntityTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "CommentRecords",
                newName: "IX_CommentRecords_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostId",
                table: "CommentRecords",
                newName: "IX_CommentRecords_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ParentCommentId",
                table: "CommentRecords",
                newName: "IX_CommentRecords_ParentCommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRecords",
                table: "UserRecords",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UniqueTagRecords",
                table: "UniqueTagRecords",
                column: "UniqueTagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagRecords",
                table: "TagRecords",
                columns: new[] { "PostId", "UniqueTagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionRecords",
                table: "SubscriptionRecords",
                columns: new[] { "SubscriberUserId", "SubscribedToUserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileRecords",
                table: "ProfileRecords",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostRecords",
                table: "PostRecords",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhotoRecords",
                table: "PhotoRecords",
                column: "PhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeRecords",
                table: "LikeRecords",
                column: "LikeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityTypeRecords",
                table: "EntityTypeRecords",
                column: "EntityTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityRecords",
                table: "EntityRecords",
                column: "EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DescriptionRecords",
                table: "DescriptionRecords",
                column: "PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentRecords",
                table: "CommentRecords",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRecords_CommentRecords_ParentCommentId",
                table: "CommentRecords",
                column: "ParentCommentId",
                principalTable: "CommentRecords",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRecords_PostRecords_PostId",
                table: "CommentRecords",
                column: "PostId",
                principalTable: "PostRecords",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRecords_UserRecords_UserId",
                table: "CommentRecords",
                column: "UserId",
                principalTable: "UserRecords",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionRecords_PostRecords_PostId",
                table: "DescriptionRecords",
                column: "PostId",
                principalTable: "PostRecords",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityRecords_EntityTypeRecords_EntityTypeId",
                table: "EntityRecords",
                column: "EntityTypeId",
                principalTable: "EntityTypeRecords",
                principalColumn: "EntityTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikeRecords_EntityRecords_EntityId",
                table: "LikeRecords",
                column: "EntityId",
                principalTable: "EntityRecords",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikeRecords_UserRecords_UserId",
                table: "LikeRecords",
                column: "UserId",
                principalTable: "UserRecords",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoRecords_EntityRecords_EntityId",
                table: "PhotoRecords",
                column: "EntityId",
                principalTable: "EntityRecords",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostRecords_UserRecords_UserId",
                table: "PostRecords",
                column: "UserId",
                principalTable: "UserRecords",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileRecords_UserRecords_UserId",
                table: "ProfileRecords",
                column: "UserId",
                principalTable: "UserRecords",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionRecords_UserRecords_SubscribedToUserId",
                table: "SubscriptionRecords",
                column: "SubscribedToUserId",
                principalTable: "UserRecords",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionRecords_UserRecords_SubscriberUserId",
                table: "SubscriptionRecords",
                column: "SubscriberUserId",
                principalTable: "UserRecords",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagRecords_PostRecords_PostId",
                table: "TagRecords",
                column: "PostId",
                principalTable: "PostRecords",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagRecords_UniqueTagRecords_UniqueTagId",
                table: "TagRecords",
                column: "UniqueTagId",
                principalTable: "UniqueTagRecords",
                principalColumn: "UniqueTagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
