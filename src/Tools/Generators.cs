using Simple.Generator;
using Locadora.Tools.Templates;
using Locadora.Tools.Macros;
using Locadora.Tools.Templates.Scaffold;
using Locadora.Tools.Templates.View;
using Locadora.Tools.Database;

namespace Locadora.Tools
{
    public static class Generators
    {
        public static CommandResolver RegisterCommands(this CommandResolver registry, bool production)
        {
            registry.Register<MigrateTool>("migrate")
                .WithOption("to", x => x.Version)
                .WithOption("script", x => x.FilePath)
                .WithOption("env", x => x.Environment);

            registry.Register<InsertDataCommand>("data").WithOption("testdata", x => x.ForceTestData);
            registry.Register<PrepareMacro>("prepare");
            registry.Register<SystemCheckMacro>("check");

            if (production)
            {
                registry.Register<TestPrepareMacro>("testprepare");
            }
            else
            {
                registry.Register<ResetDbCommand>("resetdb")
                    .WithOption("prepare", x => x.Prepare);

                registry.Register<NewMigrationTemplate>("new migration")
                    .WithArgument("name", x => x.Name)
                    .WithOption("donotopen", x => x.OpenIt);

                registry.Register<MagicMacro>("magic");

                registry.Register<ScaffoldGenerator>("scaffold")
                    .WithArgumentList("tables", x => x.TableNames);

                registry.Register<ScaffoldRemover>("d scaffold")
                   .WithArgumentList("class_names", x => x.ClassNames);

                registry.Register<ViewGenerator>("view")
                    .WithArgumentList("class_names", x => x.ClassNames);


                registry.Register<RefreshMacro>("refresh");
            }

            return registry;
        }

     
    }
}
