using Locadora.Services;
using Simple.Services;
using System.Collections.Generic;
using Simple.Patterns;

namespace Locadora.Services
{
    public partial interface ISystemService : IService
    {
        IList<TaskRunner.Result> Check();
    }
}