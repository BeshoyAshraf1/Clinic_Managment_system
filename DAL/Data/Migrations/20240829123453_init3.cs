using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GradPro.Data.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "ID", "Address", "Email", "Location", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St", "info@cityhealth.com", "Downtown", "City Health Clinic", "123-456-7890" },
                    { 2, "456 Elm St", "contact@suburbanhealth.com", "Suburb", "Suburban Health Clinic", "987-654-3210" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "ID", "Address", "Age", "Email", "Gender", "Name", "PhoneNumber", "medicalhistory" },
                values: new object[,]
                {
                    { 1, "789 Oak St", 30, "alice@example.com", 1, "Alice Johnson", "555-2345", "No significant medical history" },
                    { 2, "321 Pine St", 45, "bob@example.com", 0, "Bob Williams", "555-6789", "Hypertension" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "ID", "ClinicID", "Department", "Email", "Name", "PhoneNumber", "Position", "Specialty", "salary" },
                values: new object[,]
                {
                    { 1, 1, "Cardiology", "johndoe@clinic.com", "Dr. John Doe", "555-1234", 0, 0, 150000.0 },
                    { 2, 1, "Dermatology", "janesmith@clinic.com", "Dr. Jane Smith", "555-5678", 0, 1, 140000.0 },
                    { 3, 2, "Neurology", "emilybrown@clinic.com", "Dr. Emily Brown", "555-8765", 0, 5, 155000.0 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "ID", "AppointmentDate", "AppointmentTime", "PatientID", "ReasonForVisit", "StaffID", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 9, 30, 0, 0), 1, "Routine Checkup", 1, 0 },
                    { 2, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 14, 0, 0, 0), 2, "Skin Rash", 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "DoctorSchedules",
                columns: new[] { "Id", "Date", "EndTime", "MaxPatients", "StaffId", "StartTime", "price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 12, 0, 0, 0), 10, 1, new TimeSpan(0, 9, 0, 0, 0), 200.0 },
                    { 2, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 16, 0, 0, 0), 8, 2, new TimeSpan(0, 13, 0, 0, 0), 180.0 },
                    { 3, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Local), new TimeSpan(0, 14, 0, 0, 0), 12, 3, new TimeSpan(0, 10, 0, 0, 0), 220.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clinics",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
