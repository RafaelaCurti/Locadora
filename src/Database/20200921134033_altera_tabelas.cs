using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Migrator.Framework;
using Simple.Migrator.Fluent;
using System.Data;

namespace Locadora.Database
{
    [Migration(20200921134033)]
    public class Migration20200921134033 : FluentMigration
    {
        public override void Up(SchemaAction schema)
        {
            schema.RenameTable("t_reservation", "t_reservations");
            schema.ChangeTable("t_users", t =>
            {
                t.RenameColumn("enum_profile_users", "enum_profile_user");
            });
            schema.ChangeTable("t_clients", t =>
            {
                t.RenameColumn("enum_profile_clients", "enum_profile_client");
            });
            schema.ChangeTable("t_preferences", t =>
            {
                t.RenameColumn("id_categories", "id_category");
            });
            schema.ChangeTable("t_itens", t =>
            {
                t.RenameColumn("id_movies", "id_movie");
            });
            schema.ChangeTable("t_sales", t =>
            {
                t.RenameColumn("enum_status_sales", "enum_status_sale");
            });
        }

        public override void Down(SchemaAction schema)
        {
            schema.RenameTable("t_reservations", "t_reservation");
            schema.ChangeTable("t_users", t =>
            {
                t.RenameColumn( "enum_profile_user", "enum_profile_users");
            });
            schema.ChangeTable("t_clients", t =>
            {
                t.RenameColumn("enum_profile_client", "enum_profile_clients");
            });
            schema.ChangeTable("t_preferences", t =>
            {
                t.RenameColumn("id_category", "id_categories");
            });
            schema.ChangeTable("t_itens", t =>
            {
                t.RenameColumn("id_movie", "id_movies");
            });
            schema.ChangeTable("t_sales", t =>
            {
                t.RenameColumn("enum_status_sale", "enum_status_sales");
            });

        }
    }

}