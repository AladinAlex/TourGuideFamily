using FluentMigrator;

namespace TourGuideFamily.Dal.Migrations;

[Migration(202505222240100, TransactionBehavior.Default)]

public class TourDescription : Migration
{

    public override void Up()
    {
        Alter.Table("tours")
            .AddColumn("description").AsString().Nullable()
            .AddColumn("description_image").AsString().Nullable();

        Execute.Sql(@"
            UPDATE tours 
            SET description = name, 
                description_image = image
            WHERE description IS NULL OR description_image IS NULL");

        Alter.Table("tours")
            .AlterColumn("description").AsString().NotNullable()
            .AlterColumn("description_image").AsString().NotNullable();
    }
    public override void Down()
    {
        Delete.Column("description")
            .Column("description_image")
            .FromTable("tours");
    }
}