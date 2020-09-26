using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Generator;
using log4net;
using Simple;
using System.Reflection;
using Simple.Generator.Console;
using Locadora.Tools.Templates;
using Locadora.Tools.Templates.AutoContracts;

namespace Locadora.Tools.Macros
{
    public class RefreshMacro : ICommand
    {
        public void Execute()
        {
            new AutoContractsTemplate().Execute();
        }
    }
}
