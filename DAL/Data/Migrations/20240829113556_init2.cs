using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradPro.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Staffs_DoctorID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Departments",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Appointments",
                newName: "StaffID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments",
                newName: "IX_Appointments_StaffID");

            migrationBuilder.AlterColumn<int>(
                name: "Specialty",
                table: "Staffs",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DoctorSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MaxPatients = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSchedules_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_StaffId",
                table: "DoctorSchedules",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Staffs_StaffID",
                table: "Appointments",
                column: "StaffID",
                principalTable: "Staffs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Staffs_StaffID",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "DoctorSchedules");

            migrationBuilder.RenameColumn(
                name: "StaffID",
                table: "Appointments",
                newName: "DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_StaffID",
                table: "Appointments",
                newName: "IX_Appointments_DoctorID");

            migrationBuilder.AlterColumn<string>(
                name: "Specialty",
                table: "Staffs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Staffs",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Staffs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Departments",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Staffs_DoctorID",
                table: "Appointments",
                column: "DoctorID",
                principalTable: "Staffs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
