﻿// <auto-generated />
using System;
using ECommerce.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    partial class EcommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ECommerce.Database.TblCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"), 1L, 1);

                    b.Property<int?>("CartStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CartId")
                        .HasName("PK__Tbl_Cart__51BCD7B70C15C5A0");

                    b.HasIndex("ProductId");

                    b.ToTable("Tbl_Cart", (string)null);
                });

            modelBuilder.Entity("ECommerce.Database.TblCartStatus", b =>
                {
                    b.Property<int>("CartStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartStatusId"), 1L, 1);

                    b.Property<string>("CartStatus")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("CartStatusId")
                        .HasName("PK__Tbl_Cart__031908A883A023C5");

                    b.ToTable("Tbl_CartStatus", (string)null);
                });

            modelBuilder.Entity("ECommerce.Database.TblCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("CategoryId")
                        .HasName("PK__Tbl_Cate__19093A0BFB63B2AA");

                    b.HasIndex(new[] { "CategoryName" }, "UQ__Tbl_Cate__8517B2E04A69117E")
                        .IsUnique()
                        .HasFilter("[CategoryName] IS NOT NULL");

                    b.ToTable("Tbl_Category", (string)null);
                });

            modelBuilder.Entity("ECommerce.Database.TblMember", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("EmailId")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.HasKey("MemberId")
                        .HasName("PK__Tbl_Memb__0CF04B18B488BEA9");

                    b.HasIndex(new[] { "EmailId" }, "UQ__Tbl_Memb__7ED91ACEEF8ADB7F")
                        .IsUnique()
                        .HasFilter("[EmailId] IS NOT NULL");

                    b.ToTable("Tbl_Members", (string)null);
                });

            modelBuilder.Entity("ECommerce.Database.TblMemberRole", b =>
                {
                    b.Property<int>("MemberRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberRoleId"), 1L, 1);

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("MemberRoleId")
                        .HasName("PK__Tbl_Memb__673C212BC88BBDD8");

                    b.ToTable("Tbl_MemberRole", (string)null);
                });

            modelBuilder.Entity("ECommerce.Database.TblProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("Description")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ProductImage")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId")
                        .HasName("PK__Tbl_Prod__B40CC6CD9CB96165");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "ProductName" }, "UQ__Tbl_Prod__DD5A978A35B6DF84")
                        .IsUnique()
                        .HasFilter("[ProductName] IS NOT NULL");

                    b.ToTable("Tbl_Product", (string)null);
                });

            modelBuilder.Entity("ECommerce.Database.TblRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("RoleId")
                        .HasName("PK__Tbl_Role__8AFACE1AFCB9D533");

                    b.HasIndex(new[] { "RoleName" }, "UQ__Tbl_Role__8A2B6160E015BBDE")
                        .IsUnique()
                        .HasFilter("[RoleName] IS NOT NULL");

                    b.ToTable("Tbl_Roles", (string)null);
                });

            modelBuilder.Entity("ECommerce.Database.TblShippingDetail", b =>
                {
                    b.Property<int>("ShippingDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShippingDetailId"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<decimal?>("AmountPaid")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("City")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Country")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentType")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ShippingDetailId")
                        .HasName("PK__Tbl_Ship__FBB368517F3A09A5");

                    b.HasIndex("MemberId");

                    b.ToTable("Tbl_ShippingDetails", (string)null);
                });

            modelBuilder.Entity("ECommerce.Database.TblCart", b =>
                {
                    b.HasOne("ECommerce.Database.TblProduct", "Product")
                        .WithMany("TblCarts")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__Tbl_Cart__Produc__35BCFE0A");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Database.TblProduct", b =>
                {
                    b.HasOne("ECommerce.Database.TblCategory", "Category")
                        .WithMany("TblProducts")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Tbl_Produ__Categ__286302EC");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ECommerce.Database.TblShippingDetail", b =>
                {
                    b.HasOne("ECommerce.Database.TblMember", "Member")
                        .WithMany("TblShippingDetails")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK__Tbl_Shipp__Membe__300424B4");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("ECommerce.Database.TblCategory", b =>
                {
                    b.Navigation("TblProducts");
                });

            modelBuilder.Entity("ECommerce.Database.TblMember", b =>
                {
                    b.Navigation("TblShippingDetails");
                });

            modelBuilder.Entity("ECommerce.Database.TblProduct", b =>
                {
                    b.Navigation("TblCarts");
                });
#pragma warning restore 612, 618
        }
    }
}
