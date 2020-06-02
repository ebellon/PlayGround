using Playground.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Playground.Common
{
    internal class ConceptManager : IManageConcepts
    {
        private IEnumerable<IProvideConcept> concepts;
        private IEnumerable<IProvideAsyncConcept> asyncConcepts;


        public ConceptManager(IEnumerable<IProvideConcept> concepts, IEnumerable<IProvideAsyncConcept> asyncConcepts)
        {
            this.concepts = concepts;
            this.asyncConcepts = asyncConcepts;
        }

        public async Task RunAll()
        {
            foreach (var asyncConcept in asyncConcepts)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"EXECUTING ASYNC CONCEPT {asyncConcept}");
                await asyncConcept.RunConceptAsync().ConfigureAwait(false);
                Console.WriteLine($"FINISHING ASYNC CONCEPT {asyncConcept}");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(string.Empty);
            }

            foreach (var concept in concepts)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"EXECUTING CONCEPT {concept}");
                concept.RunConcept();
                Console.WriteLine($"FINISHING CONCEPT {concept}");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(string.Empty);
            }
        }
    }
}
