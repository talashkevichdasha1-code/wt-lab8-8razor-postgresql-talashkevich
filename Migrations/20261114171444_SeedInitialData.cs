using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wt_lab8_8razor_postgresql_talashkevich.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "TrainingSessions",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "MembershipPlans",
                columns: new[] { "Id", "DurationMonths", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Стандарт", 80m },
                    { 2, 3, "Премиум", 200m },
                    { 3, 12, "Годовой", 600m }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "ExperienceYears", "Name", "Specialization" },
                values: new object[,]
                {
                    { 1, 8, "Александр Волков", "Силовые тренировки" },
                    { 2, 5, "Мария Соколова", "Фитнес и растяжка" },
                    { 3, 6, "Дмитрий Орлов", "Кардиотренировки" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Age", "IsActive", "MembershipPlanId", "Name", "TrainerId" },
                values: new object[,]
                {
                    { 1, 22, true, 2, "Анна Петрова", 1 },
                    { 2, 25, true, 1, "Максим Иванов", 2 },
                    { 3, 21, true, 3, "Елена Смирнова", 2 },
                    { 4, 30, false, 1, "Дмитрий Козлов", 3 },
                    { 5, 24, true, 2, "София Морозова", 1 }
                });

            migrationBuilder.InsertData(
                table: "TrainingSessions",
                columns: new[] { "Id", "DurationMinutes", "MemberId", "StartTime", "Title", "TrainerId" },
                values: new object[,]
                {
                    { 1, 60, 1, new DateTime(2026, 10, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Силовая тренировка", 1 },
                    { 2, 45, 2, new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), "Фитнес и растяжка", 2 },
                    { 3, 30, 3, new DateTime(2026, 10, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), "Кардиотренировка", 3 },
                    { 4, 60, 4, new DateTime(2026, 10, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), "Персональная тренировка", 3 },
                    { 5, 90, 5, new DateTime(2026, 10, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), "Комплексная тренировка", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingSessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainingSessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainingSessions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrainingSessions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrainingSessions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MembershipPlans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MembershipPlans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MembershipPlans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "TrainingSessions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
