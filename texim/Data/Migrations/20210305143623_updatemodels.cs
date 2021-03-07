using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace texim.Data.Migrations
{
    public partial class updatemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "WebHtmls",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "WebBanners",
                newName: "UpdateAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "WebHtmls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "WebHtmls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "WebHtmls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "WebHtmls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "WebHtmls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "WebHtmls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeyword",
                table: "WebHtmls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "WebHtmls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "WebHtmls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "WebBanners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "WebBanners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "WebBanners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "WebBanners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "WebBanners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "WebBanners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeyword",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ProductImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "ProductImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "ProductCategorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "ProductCategorys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "ProductCategorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "ProductCategorys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "ProductCategorys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "ProductCategorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "ProductCategorys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeyword",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "BlogTags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "BlogTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "BlogTags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "BlogTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "BlogTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "BlogTags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "BlogTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "BlogCategorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreateBy",
                table: "BlogCategorys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteAt",
                table: "BlogCategorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeleteBy",
                table: "BlogCategorys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "BlogCategorys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "BlogCategorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdateBy",
                table: "BlogCategorys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "WebHtmls");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "WebHtmls");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "WebHtmls");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "WebHtmls");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "WebHtmls");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "WebHtmls");

            migrationBuilder.DropColumn(
                name: "MetaKeyword",
                table: "WebHtmls");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "WebHtmls");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "WebHtmls");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "WebBanners");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "WebBanners");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "WebBanners");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "WebBanners");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "WebBanners");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "WebBanners");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "MetaKeyword",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "ProductCategorys");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "ProductCategorys");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "ProductCategorys");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "ProductCategorys");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "ProductCategorys");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "ProductCategorys");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "ProductCategorys");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "MetaKeyword",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "BlogTags");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "BlogCategorys");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "BlogCategorys");

            migrationBuilder.DropColumn(
                name: "DeleteAt",
                table: "BlogCategorys");

            migrationBuilder.DropColumn(
                name: "DeleteBy",
                table: "BlogCategorys");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "BlogCategorys");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "BlogCategorys");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "BlogCategorys");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "WebHtmls",
                newName: "LastModified");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "WebBanners",
                newName: "LastModified");
        }
    }
}
