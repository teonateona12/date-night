using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace date_night_admin.Migrations
{
    /// <inheritdoc />
    public partial class SyncCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // No action needed in the Up method since the 'Categories' table already exists
            // You can include migration operations here if you want to make additional changes to the table
            // For example:
            // migrationBuilder.AddColumn<string>(
            //     name: "NewColumn",
            //     table: "Categories",
            //     nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // No action needed in the Down method since this migration only synchronizes the existing table
            // You can include migration operations here if you need to revert any changes made in the Up method
            // For example:
            // migrationBuilder.DropColumn(
            //     name: "NewColumn",
            //     table: "Categories");
        }
    }
}
