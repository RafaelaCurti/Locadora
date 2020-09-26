using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Migrator.Framework;
using Simple.Migrator.Fluent;
using System.Data;

namespace Locadora.Database
{
    [Migration(20200921111958)]
    public class Migration20200921111958 : FluentMigration
    {
        public override void Up(SchemaAction schema)
        {
            schema.AddTable("t_movies", t =>
            {
                t.AddString("code");
                t.AddString("name");
                t.AddInt32("duration");
                t.AddInt32("enum_format_movie").NotNullable().Default(0);
                t.AddInt32("enum_type_movie").NotNullable().Default(0);
                t.AddInt32("stock").NotNullable().Default(0);
                t.AddDateTime("date").NotNullable().Default("getdate()");
            });

        }

        public override void Down(SchemaAction schema)
        {
            schema.RemoveTable("t_movies");
        }
    }

}