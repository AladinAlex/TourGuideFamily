using FluentMigrator;

namespace TourGuideFamily.Dal.Migrations;

[Migration(202506152043100, TransactionBehavior.Default)]

public class TourSortOrder : Migration
{

    public override void Up()
    {
        Alter.Table("tours")
            .AddColumn("sort_order").AsInt16().Nullable();

        Execute.Sql(@"
            UPDATE tours 
            SET sort_order = id
            WHERE sort_order IS NULL");

        Alter.Table("tours")
            .AlterColumn("sort_order").AsInt16().NotNullable();
    }
    public override void Down()
    {
        Delete.Column("sort_order") 
            .FromTable("tours");
    }
}