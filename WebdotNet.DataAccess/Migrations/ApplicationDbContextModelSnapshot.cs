﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebdotNet.DataAccess.Data;

#nullable disable

namespace WebdotNet.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebdotNet.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            ID = 2,
                            DisplayOrder = 2,
                            Name = "Horror"
                        },
                        new
                        {
                            ID = 3,
                            DisplayOrder = 3,
                            Name = "SciFi"
                        },
                        new
                        {
                            ID = 4,
                            DisplayOrder = 4,
                            Name = "History"
                        },
                        new
                        {
                            ID = 5,
                            DisplayOrder = 5,
                            Name = "Comedy"
                        },
                        new
                        {
                            ID = 6,
                            DisplayOrder = 6,
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("WebdotNet.Models.Products", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("imgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Author = "Suzanne Collins",
                            Category = "Action",
                            Description = "A dystopian novel set in a post-apocalyptic world.",
                            ISBN = "9780439023481",
                            ListPrice = 10.99,
                            Price = 9.9900000000000002,
                            Price100 = 7.9900000000000002,
                            Price50 = 8.9900000000000002,
                            Title = "The Hunger Games",
                            imgUrl = ""
                        },
                        new
                        {
                            ID = 2,
                            Author = "Bram Stoker",
                            Category = "Horror",
                            Description = "A horror novel about the vampire Count Dracula.",
                            ISBN = "9780141439846",
                            ListPrice = 8.9900000000000002,
                            Price = 7.9900000000000002,
                            Price100 = 5.9900000000000002,
                            Price50 = 6.9900000000000002,
                            Title = "Dracula",
                            imgUrl = ""
                        },
                        new
                        {
                            ID = 3,
                            Author = "Frank Herbert",
                            Category = "SciFi",
                            Description = "A science fiction novel set in a distant future amidst a huge interstellar empire.",
                            ISBN = "9780441013593",
                            ListPrice = 9.9900000000000002,
                            Price = 8.9900000000000002,
                            Price100 = 6.9900000000000002,
                            Price50 = 7.9900000000000002,
                            Title = "Dune",
                            imgUrl = ""
                        },
                        new
                        {
                            ID = 4,
                            Author = "Yuval Noah Harari",
                            Category = "History",
                            Description = "A brief history of humankind.",
                            ISBN = "9780062316097",
                            ListPrice = 14.99,
                            Price = 13.99,
                            Price100 = 11.99,
                            Price50 = 12.99,
                            Title = "Sapiens",
                            imgUrl = ""
                        },
                        new
                        {
                            ID = 5,
                            Author = "Tina Fey",
                            Category = "Comedy",
                            Description = "A comedy memoir by Tina Fey.",
                            ISBN = "9780316056892",
                            ListPrice = 12.99,
                            Price = 11.99,
                            Price100 = 9.9900000000000002,
                            Price50 = 10.99,
                            Title = "Bossypants",
                            imgUrl = ""
                        },
                        new
                        {
                            ID = 6,
                            Author = "Jane Austen",
                            Category = "Romance",
                            Description = "A romance novel by Jane Austen.",
                            ISBN = "9780141040349",
                            ListPrice = 7.9900000000000002,
                            Price = 6.9900000000000002,
                            Price100 = 4.9900000000000002,
                            Price50 = 5.9900000000000002,
                            Title = "Pride and Prejudice",
                            imgUrl = ""
                        },
                        new
                        {
                            ID = 7,
                            Author = "Suzanne Collins",
                            Category = "Action",
                            Description = "The second book in The Hunger Games series.",
                            ISBN = "9780439023498",
                            ListPrice = 10.99,
                            Price = 9.9900000000000002,
                            Price100 = 7.9900000000000002,
                            Price50 = 8.9900000000000002,
                            Title = "Catching Fire",
                            imgUrl = ""
                        },
                        new
                        {
                            ID = 8,
                            Author = "Mary Shelley",
                            Category = "Horror",
                            Description = "A horror novel about a scientist who creates a monster.",
                            ISBN = "9780141439471",
                            ListPrice = 8.9900000000000002,
                            Price = 7.9900000000000002,
                            Price100 = 5.9900000000000002,
                            Price50 = 6.9900000000000002,
                            Title = "Frankenstein",
                            imgUrl = ""
                        },
                        new
                        {
                            ID = 9,
                            Author = "William Gibson",
                            Category = "SciFi",
                            Description = "A science fiction novel that tells the story of a washed-up computer hacker.",
                            ISBN = "9780441569595",
                            ListPrice = 9.9900000000000002,
                            Price = 8.9900000000000002,
                            Price100 = 6.9900000000000002,
                            Price50 = 7.9900000000000002,
                            Title = "Neuromancer",
                            imgUrl = ""
                        },
                        new
                        {
                            ID = 10,
                            Author = "Jared Diamond",
                            Category = "History",
                            Description = "A history book that explores the factors that contributed to the development of human societies.",
                            ISBN = "9780393354324",
                            ListPrice = 14.99,
                            Price = 13.99,
                            Price100 = 11.99,
                            Price50 = 12.99,
                            Title = "Guns, Germs, and Steel",
                            imgUrl = ""
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
