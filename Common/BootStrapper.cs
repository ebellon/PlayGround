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

              //Implementations
              .AddSingleton<IThrowExceptions, ExceptionThrowerConcept>()
              .AddSingleton<IHandleCancellationTokens, CancellationTokenConcept>()
              .AddSingleton<IHandleAsyncAwait, AsyncAwaitConcept>()

              // Concept
              .AddSingleton<IProvideConcept, CancellationTokenConcept>()
              .AddSingleton<IProvideConcept, ExceptionThrowerConcept>()
              .AddSingleton<IProvideAsyncConcept, AsyncAwaitConcept>()

             // Concept manager
             .AddSingleton<IManageConcepts, ConceptManager>()
              .BuildServiceProvider();
        }
    }
}