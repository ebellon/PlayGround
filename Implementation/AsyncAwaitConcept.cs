using Playground.Interfaces;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Implementation
{
    internal class AsyncAwaitConcept : IHandleAsyncAwait, IProvideAsyncConcept
    {
        public Task LongRunningOperation(CancellationToken cancellationToken, TimeSpan timeoutInSeconds)
        {
            var stopWatch = Stopwatch.StartNew();

            while (stopWatch.Elapsed.TotalSeconds < timeoutInSeconds.TotalSeconds)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Task.Delay(50).Wait();
                Console.WriteLine($"Wheels on the bus go round and round.. Ellapsed {stopWatch.ElapsedMilliseconds} ms");
            }
            return Task.FromResult<object>(null);
        }

        public async Task RunConceptAsync()
        {
            try
            {
                await LongRunningOperation(CancellationToken.None, TimeSpan.FromSeconds(1)).ConfigureAwait(false);
                Console.WriteLine("Finished!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e} {e.Message}");
            }
        }
    }
}
