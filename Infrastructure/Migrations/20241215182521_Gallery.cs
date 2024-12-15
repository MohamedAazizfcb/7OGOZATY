using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Gallery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseGallery_Clinic_ClinicId",
                table: "BaseGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseGallery",
                table: "BaseGallery");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseGallery");

            migrationBuilder.DropColumn(
                name: "ImageDescription",
                table: "BaseGallery");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BaseGallery");

            migrationBuilder.RenameTable(
                name: "BaseGallery",
                newName: "ClinicGallery");

            migrationBuilder.RenameIndex(
                name: "IX_BaseGallery_ClinicId",
                table: "ClinicGallery",
                newName: "IX_ClinicGallery_ClinicId");

            migrationBuilder.AddColumn<string>(
                name: "imgUrl",
                table: "ClinicGallery",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClinicGallery",
                table: "ClinicGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicGallery_Clinic_ClinicId",
                table: "ClinicGallery",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClinicGallery_Clinic_ClinicId",
                table: "ClinicGallery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClinicGallery",
                table: "ClinicGallery");

            migrationBuilder.DropColumn(
                name: "imgUrl",
                table: "ClinicGallery");

            migrationBuilder.RenameTable(
                name: "ClinicGallery",
                newName: "BaseGallery");

            migrationBuilder.RenameIndex(
                name: "IX_ClinicGallery_ClinicId",
                table: "BaseGallery",
                newName: "IX_BaseGallery_ClinicId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseGallery",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageDescription",
                table: "BaseGallery",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BaseGallery",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseGallery",
                table: "BaseGallery",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseGallery_Clinic_ClinicId",
                table: "BaseGallery",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
