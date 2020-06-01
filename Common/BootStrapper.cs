using Microsoft.Extensions.DependencyInjection;
using Playground.Implementation;
using Playground.Interfaces;

namespace Playground.Common
{
    public static class BootStrapper
    {
        public static ServiceProvider Setup()
        {
            return new ServiceCollection()
              .AddSingleton<IThrowExceptions, ExceptionThrowerConcept>()
              .AddSingleton<IProvideConcept, ExceptionThrowerConcept>()
              .AddSingleton<IHandleCancellationTokens, CancellationTokenConcept>()
              .AddSingleton<IProvideConcept, CancellationTokenConcept>()
              .AddSingleton<IManageConcepts, ConceptManager>()
              .BuildServiceProvider();
        }
    }
}