using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Generator;
using Simple.Generator.Console;
using Simple;
using Simple.Patterns;

namespace Locadora.Tools
{ 
    public class Context : ContextBase
    {
        public static IDisposable Development
        {
            get { return Simply.KeyContext(null).ComposeWith(Simply.Do.EnterContext()); }
        }
        public static IDisposable Test
        {
            get { return Simply.KeyContext(Configurator.Test).ComposeWith(Simply.Do.EnterContext()); }
        }
        
        public Context(string defaultEnv)
            : base(Configurator.DefaultNamespace, defaultEnv)
        {
        }

        protected override CommandResolver Configure()
        {
            var resolver = new CommandResolver().WithHelp()
                .RegisterCommands(Configurator.IsProduction);

            InternalConfigure(DefaultEnvironment);

            if (!Configurator.IsProduction)
                InternalConfigure(Configurator.Test);

            return resolver;
        }

        protected void InternalConfigure(params string[] names)
        {
            names = names ?? new string[] { null };
            foreach (var name in names)
                new Configurator(name, name).StartServer<ServerStarter>();
        }
    }
}
