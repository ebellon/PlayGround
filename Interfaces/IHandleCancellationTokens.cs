using System;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Interfaces
{
    interface IHandleCancellationTokens
    {
        void CancellableTask(CancellationToken cancellationToken, TimeSpan timeoutInSeconds);
    }
}
