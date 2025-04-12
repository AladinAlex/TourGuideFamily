using FluentMigrator;

namespace TourGuideFamily.Dal.Migrations;

[Migration(202503172249100, TransactionBehavior.None)]
public class CreateInclusionType : Migration
{
    public override void Up()
    {
        var sql = @"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'inclusion_type') THEN
            CREATE TYPE inclusion_type as
            (
                  id              bigint
                , tour_id         bigint
                , description     text
                , include         boolean
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
        DROP TYPE IF EXISTS inclusion_type;
    END
$$;";

        Execute.Sql(sql);
    }
}