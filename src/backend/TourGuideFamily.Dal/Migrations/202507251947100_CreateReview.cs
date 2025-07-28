using FluentMigrator;

namespace TourGuideFamily.Dal.Migrations;

[Migration(202507251947100, TransactionBehavior.Default)]

public class CreateReview : Migration
{

    public override void Up()
    {
        Create.Table("reviews")
            .WithColumn("id").AsInt64().PrimaryKey("reviews_pk").Identity()
            .WithColumn("firstname").AsString().NotNullable()
            .WithColumn("rating").AsInt16().NotNullable()
            .WithColumn("tour_name").AsString().Nullable()
            .WithColumn("description").AsString().NotNullable()
            .WithColumn("created_on").AsDate().NotNullable();
    }
    public override void Down()
    {
        Delete.Table("reviews");
    }
}