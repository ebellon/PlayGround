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
              .AddSingleton<IHandleExceptions, ExceptionThrowerConcept>()
              .AddSingleton<IHandleCancellationTokens, CancellationTokenConcept>()
              .AddSingleton<IHandleAsyncAwait, AsyncAwaitConcept>()
              .AddSingleton<IHandleBoxing, BoxingConcept>()

              // Concept
              .AddSingleton<IProvideConcept, CancellationTokenConcept>()
              .AddSingleton<IProvideConcept, ExceptionThrowerConcept>()
              .AddSingleton<IProvideConcept, BoxingConcept>()
              .AddSingleton<IProvideAsyncConcept, AsyncAwaitConcept>()

             // Concept manager
             .AddSingleton<IManageConcepts, ConceptManager>()
             .BuildServiceProvider();
        }
    }
}