using Playground.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Playground.Implementation
{
    class BoxingConcept : IHandleBoxing, IProvideConcept
    {
        public void BoxAndUnbox()
        {
            List<object> objectList = new List<object>();

            var stopWatch = Stopwatch.StartNew();

            objectList.Add(3);
            objectList.Add(10);
            objectList.Add(1);
            stopWatch.Stop();

            Console.WriteLine($"Boxing took {stopWatch.Elapsed.TotalMilliseconds} ms.");

            stopWatch.Reset();
            stopWatch.Start();
            foreach (var obj in objectList)
            {
                _ = (int)obj;
            }

            stopWatch.Stop();

            Console.WriteLine($"Unboxing took {stopWatch.Elapsed.TotalMilliseconds} ms.");
        }

        public void RunConcept()
        {
            this.BoxAndUnbox();
        }
    }
}
