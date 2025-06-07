using FluentMigrator;

namespace TourGuideFamily.Dal.Migrations;

[Migration(202504222106100, TransactionBehavior.Default)]
public class AddMinMaxHourDurationTour : Migration
{

    public override void Up()
    {
        Alter.Table("tours")
            .AddColumn("duration_hour_max")
            .AsInt16()
            .Nullable();

        Rename.Column("duration_hour")
            .OnTable("tours")
            .To("duration_hour_min");

    }
    public override void Down()
    {

        Rename.Column("duration_hour_min")
            .OnTable("tours")
            .To("duration_hour");

        Delete.Column("duration_hour_max")
            .FromTable("tours");
    }
}