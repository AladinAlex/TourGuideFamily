using FluentMigrator;

namespace TourGuideFamily.Dal.Migrations;

[Migration(202503172258100, TransactionBehavior.None)]
public class CreatePromoType : Migration
{
    public override void Up()
    {
        var sql = @"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'promo_type') THEN
            CREATE TYPE promo_type as
            (
                  id            bigint
                , tour_id       bigint
                , image         text
                , name          text
                , description   text
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
        DROP TYPE IF EXISTS promo_type;
    END
$$;";

        Execute.Sql(sql);
    }
}