using System.Collections.Generic;
using System.ComponentModel;

namespace Locadora.Domain
{
    public partial class TMovie
    {
        public virtual List<TCategory> Category { get; set; }
        public virtual int[] Categories { get; set; }
    }
}
