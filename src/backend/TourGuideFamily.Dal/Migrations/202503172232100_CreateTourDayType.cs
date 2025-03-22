using FluentMigrator;

namespace TourGuideFamily.Dal.Migrations;

[Migration(202503172232100, TransactionBehavior.None)]
public class CreateTourDayType : Migration
{
    public override void Up()
    {
        var sql = @"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'tour_day_type') THEN
            CREATE TYPE tour_day_type as
            (
                  id          bigint
                , tour_id     bigint
                , number      smallint
                , image       text
                , name        text
                , description text
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
        DROP TYPE IF EXISTS tour_day_type;
    END
$$;";

        Execute.Sql(sql);
    }
}