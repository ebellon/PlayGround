using Playground.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Implementation
{
    internal class CancellationTokenConcept : IHandleCancellationTokens, IProvideConcept
    {
        public void LongRunningOperation(CancellationToken cancellationToken, TimeSpan timeoutInSeconds)
        {
            var stopWatch = Stopwatch.StartNew();

            while (stopWatch.Elapsed.TotalSeconds < timeoutInSeconds.TotalSeconds)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Thread.Sleep(50);
                Console.WriteLine($"Wheels on the bus go round and round.. Ellapsed {stopWatch.ElapsedMilliseconds} ms");
            }
        }

        public void RunConcept()
        { 
            var cancellationToken = new CancellationTokenSource(200);

            try
            {
                Task.Run(() => this.LongRunningOperation(cancellationToken.Token, TimeSpan.FromSeconds(1))).Wait();
            }
            catch (AggregateException ex)
            {
                ex.InnerExceptions.ToList().ForEach(e => Console.WriteLine($"{e} {e.Message}"));
            }
        }

        public Task RunConceptAsync()
        {
            throw new NotImplementedException();
        }
    }
}
