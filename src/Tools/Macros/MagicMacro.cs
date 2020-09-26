using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Generator;
using Locadora.Tools.Templates.Scaffold;

namespace Locadora.Tools.Macros
{
    public class MagicMacro : ICommand
    {
        #region ICommand Members

        public void Execute()
        {
            new PrepareMacro().Execute();
            new ScaffoldGenerator().Execute();
        }

        #endregion
    }
}
