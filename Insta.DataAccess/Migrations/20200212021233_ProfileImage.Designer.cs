﻿// <auto-generated />
using System;
using Insta.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Insta.DataAccess.Migrations
{
    [DbContext(typeof(InstaContext))]
    [Migration("20200212021233_ProfileImage")]
    partial class ProfileImage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Insta.DataAccess.Records.CommentRecord", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CommentId");

                    b.HasIndex("ParentCommentId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.DescriptionRecord", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostId");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.EntityRecord", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntityTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ExternalEntityId")
                        .HasColumnType("int");

                    b.HasKey("EntityId");

                    b.HasIndex("EntityTypeId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.EntityTypeRecord", b =>
                {
                    b.Property<int>("EntityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityTypeId");

                    b.ToTable("EntityTypes");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.LikeRecord", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LikeId");

                    b.HasIndex("EntityId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.PhotoRecord", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CloudUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("PhotoId");

                    b.HasIndex("EntityId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.PostRecord", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Geolocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.ProfileRecord", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImageCloudUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.SubscriptionRecord", b =>
                {
                    b.Property<Guid>("SubscriberUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubscribedToUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("SubscriberUserId", "SubscribedToUserId");

                    b.HasIndex("SubscribedToUserId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.TagRecord", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UniqueTagId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "UniqueTagId");

                    b.HasIndex("UniqueTagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.UniqueTagRecord", b =>
                {
                    b.Property<int>("UniqueTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UniqueTagId");

                    b.ToTable("UniqueTags");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.UserRecord", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EncryptedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Insta.DataAccess.Records.CommentRecord", b =>
                {
                    b.HasOne("Insta.DataAccess.Records.CommentRecord", "ParentComment")
                        .WithMany("Comments")
                        .HasForeignKey("ParentCommentId");

                    b.HasOne("Insta.DataAccess.Records.PostRecord", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insta.DataAccess.Records.UserRecord", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Insta.DataAccess.Records.DescriptionRecord", b =>
                {
                    b.HasOne("Insta.DataAccess.Records.PostRecord", "Post")
                        .WithOne("Description")
                        .HasForeignKey("Insta.DataAccess.Records.DescriptionRecord", "PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Insta.DataAccess.Records.EntityRecord", b =>
                {
                    b.HasOne("Insta.DataAccess.Records.EntityTypeRecord", "EntityType")
                        .WithMany("Entities")
                        .HasForeignKey("EntityTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Insta.DataAccess.Records.LikeRecord", b =>
                {
                    b.HasOne("Insta.DataAccess.Records.EntityRecord", "Entity")
                        .WithMany("Likes")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insta.DataAccess.Records.UserRecord", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Insta.DataAccess.Records.PhotoRecord", b =>
                {
                    b.HasOne("Insta.DataAccess.Records.EntityRecord", "Entity")
                        .WithMany("Photos")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Insta.DataAccess.Records.PostRecord", b =>
                {
                    b.HasOne("Insta.DataAccess.Records.UserRecord", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Insta.DataAccess.Records.ProfileRecord", b =>
                {
                    b.HasOne("Insta.DataAccess.Records.UserRecord", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Insta.DataAccess.Records.ProfileRecord", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Insta.DataAccess.Records.SubscriptionRecord", b =>
                {
                    b.HasOne("Insta.DataAccess.Records.UserRecord", "SubscribedToUser")
                        .WithMany("Subscribers")
                        .HasForeignKey("SubscribedToUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Insta.DataAccess.Records.UserRecord", "SubscriberUser")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SubscriberUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Insta.DataAccess.Records.TagRecord", b =>
                {
                    b.HasOne("Insta.DataAccess.Records.PostRecord", "Post")
                        .WithMany("Tags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insta.DataAccess.Records.UniqueTagRecord", "UniqueTag")
                        .WithMany("Tags")
                        .HasForeignKey("UniqueTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}