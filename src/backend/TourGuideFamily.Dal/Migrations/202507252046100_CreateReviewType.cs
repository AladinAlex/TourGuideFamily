using FluentMigrator;

namespace TourGuideFamily.Dal.Migrations;

[Migration(202507252046100, TransactionBehavior.None)]
public class CreateReviewType : Migration
{
    public override void Up()
    {
        var sql = @"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'review_type') THEN
            CREATE TYPE review_type as
            (
                  id            bigint
                , firstname     text
                , rating        smallint
                , tour_name     text
                , description   text
                , created_on    date
            );
        END IF;
    END
$$;";

        Execute.Sql(sql);
    }

    public override void Down()
    {
        const string sql = @"
DO $$
    BEGIN
        DROP TYPE IF EXISTS review_type;
    END
$$;";

        Execute.Sql(sql);
    }
}