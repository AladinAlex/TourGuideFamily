using FluentMigrator;

namespace TourGuideFamily.Dal.Migrations;

[Migration(202503162116100, TransactionBehavior.None)]
public class InitSchema : Migration
{
    public override void Up()
    {
        Create.Table("tours")
            .WithColumn("id").AsInt64().PrimaryKey("tours_pk").Identity()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("description").AsString().NotNullable()
            .WithColumn("min_participants").AsInt16().NotNullable()
            .WithColumn("max_participants").AsInt16().NotNullable()
            .WithColumn("price").AsDecimal().NotNullable()
            .WithColumn("duration_hour").AsInt16().Nullable();

        Create.Table("tour_days")
            .WithColumn("id").AsInt64().PrimaryKey("tour_days_pk").Identity()
            .WithColumn("tour_id").AsInt64().NotNullable()
            .WithColumn("number").AsInt16().NotNullable()
            .WithColumn("image").AsString().NotNullable()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("description").AsString().NotNullable();

        Create.Table("inclusions")
            .WithColumn("id").AsInt64().PrimaryKey("inclusions_pk").Identity()
            .WithColumn("tour_id").AsInt64().NotNullable()
            .WithColumn("description").AsString().NotNullable()
            .WithColumn("include").AsBoolean().NotNullable();

        Create.Table("promos")
            .WithColumn("id").AsInt64().PrimaryKey("promos_pk").Identity()
            .WithColumn("tour_id").AsInt64().Nullable()
            .WithColumn("image").AsString().NotNullable()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("description").AsString().NotNullable();

        Create.Table("feedback")
            .WithColumn("id").AsInt64().PrimaryKey("feedback_pk").Identity()
            .WithColumn("firstname").AsString().NotNullable()
            .WithColumn("phone_number").AsString().NotNullable()
            .WithColumn("contact_method").AsInt16().NotNullable()
            .WithColumn("tour_id").AsInt64().Nullable()
            .WithColumn("created_on").AsDateTimeOffset().NotNullable();

        Create.Table("guides")
            .WithColumn("id").AsInt64().PrimaryKey("guides_pk").Identity()
            .WithColumn("image").AsString().NotNullable()
            .WithColumn("firstname").AsString().NotNullable()
            .WithColumn("surname").AsString().NotNullable()
            .WithColumn("description").AsString().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("tours");
        Delete.Table("tour_days");
        Delete.Table("inclusions");
        Delete.Table("promos");
        Delete.Table("feedback");
        Delete.Table("guides");
    }
}