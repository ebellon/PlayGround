using System;
using System.Threading;

namespace Playground.Interfaces
{
    interface IHandleCancellationTokens
    {
        void LongRunningOperation(CancellationToken cancellationToken, TimeSpan timeoutInSeconds);
    }
}
