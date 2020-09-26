using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Migrator.Framework;
using Simple.Migrator.Fluent;
using System.Data;

namespace Locadora.Database
{
    [Migration(20200921114425)]
    public class Migration20200921114425 : FluentMigration
    {
        public override void Up(SchemaAction schema)
        {
            schema.ChangeTable("t_movies", t =>
            {
                t.AddBoolean("is_active").NotNullable().Default(1);
            });

            schema.AddTable("t_categories", t =>
            {
                t.AddString("name");
            });

            schema.AddTable("t_movie_categories", t =>
            {
                t.AddInt32("id_movie").NotNullable().AutoForeignKey("t_movies");
                t.AddInt32("id_category").NotNullable().AutoForeignKey("t_categories");
            });

        }

        public override void Down(SchemaAction schema)
        {
            schema.RemoveTable("t_movie_categories");
            schema.RemoveTable("t_categories");
            schema.ChangeTable("t_movies", t =>
            {
                t.RemoveColumn("is_active");
            });
        }
    }

}