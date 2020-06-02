using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Interfaces
{
    interface IHandleAsyncAwait
    {
        Task LongRunningOperation(CancellationToken cancellationToken, TimeSpan timeoutInSeconds);
    }
}
