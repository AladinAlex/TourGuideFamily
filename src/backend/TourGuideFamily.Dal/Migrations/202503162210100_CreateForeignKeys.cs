using FluentMigrator;

namespace TourGuideFamily.Dal.Migrations;

[Migration(202503162210100, TransactionBehavior.None)]
public class CreateForeignKeys : Migration
{
    public override void Up()
    {
        Create.ForeignKey("tour_tour_day_fk")
            .FromTable("tour_days").ForeignColumn("tour_id")
            .ToTable("tours").PrimaryColumn("id")
            .OnDelete(System.Data.Rule.Cascade);

        Create.ForeignKey("tour_inclusions_fk")
            .FromTable("inclusions").ForeignColumn("tour_id")
            .ToTable("tours").PrimaryColumn("id")
            .OnDelete(System.Data.Rule.Cascade);
    }

    public override void Down()
    {
        Delete.ForeignKey("tour_tour_day_fk");
        Delete.ForeignKey("tour_inclusions_fk");
    }
}