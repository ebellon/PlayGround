
using Microsoft.Extensions.DependencyInjection;
using Playground.Common;
using Playground.Interfaces;

namespace Playground
{
    class Program
    {
        static void Main()
        {
            using (var bootStrapper = BootStrapper.Setup())
            {
                var conceptManager = bootStrapper.GetService<IManageConcepts>();
                conceptManager.RunAll();
            }
        }
    }
}

