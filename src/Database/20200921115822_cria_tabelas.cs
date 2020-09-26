using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Migrator.Framework;
using Simple.Migrator.Fluent;
using System.Data;

namespace Locadora.Database
{
    [Migration(20200921115822)]
    public class Migration20200921115822 : FluentMigration
    {
        public override void Up(SchemaAction schema)
        {
            schema.AddTable("t_users", t =>
            {
                t.AddString("name");
                t.AddBinary("password").NotNullable().WithSize(48);
                t.AddInt32("enum_profile_users").NotNullable().Default(0);
            });

            schema.AddTable("t_clients", t =>
            {
                t.AddString("name");
                t.AddString("email");
                t.AddString("telephone");
                t.AddString("login");
                t.AddBinary("password").NotNullable().WithSize(48);
                t.AddInt32("enum_profile_clients").NotNullable().Default(0);

            });

            schema.AddTable("t_preferences", t =>
             {
                 t.AddInt32("id_client").NotNullable().AutoForeignKey("t_clients");
                 t.AddInt32("id_categories").NotNullable().AutoForeignKey("t_categories");
                 t.AddInt32("enum_type_movie").NotNullable().Default(0);
             });


            schema.AddTable("t_reservation", t =>
            {
                t.AddInt32("id_client").NotNullable().AutoForeignKey("t_clients");
                t.AddDateTime("withdraw").NotNullable();
                t.AddDateTime("devolution").NotNullable();
            });

            schema.AddTable("t_itens", t =>
            {
                t.AddInt32("id_reservation").NotNullable().AutoForeignKey("t_reservations");
                t.AddInt32("id_movies").NotNullable().AutoForeignKey("t_movies");
                t.AddDouble("value").NotNullable().Default(0.0);
                t.AddInt32("quantity").NotNullable().Default(0);
            });

            schema.AddTable("t_sales", t =>
            {
                t.AddInt32("id_reservation").NotNullable().AutoForeignKey("t_reservations");
                t.AddInt32("enum_status_sales").NotNullable().Default(0);
            });



        }


        public override void Down(SchemaAction schema)
        {
            schema.RemoveTable("t_sales");
            schema.RemoveTable("t_itens");
            schema.RemoveTable("t_reservation");
            schema.RemoveTable("t_preferences");
            schema.RemoveTable("t_client");
            schema.RemoveTable("t_users");


        }
    }

}