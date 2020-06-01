using System;
using Playground.Interfaces;

namespace Playground.Common
{
    internal class ExceptionThrowerConcept : IThrowExceptions, IProvideConcept
    {
        public void RethrowException(bool withEx)
        {
            try
            {
                this.ThrowException();
            }
            catch (Exception ex)
            {
                if (withEx)
                {
#pragma warning disable S3445 // Exceptions should not be explicitly rethrown
                    throw ex;
#pragma warning restore S3445 // Exceptions should not be explicitly rethrown
                }
                else
                {
                    throw;
                }
            }
        }

        public void RunConcept()
        {
            this.ExceptionCatcher(true);
            this.ExceptionCatcher(false);
        }

        public void ThrowException()
        {
            throw new ArgumentException("This is a test");
        }

        private void ExceptionCatcher(bool withEx)
        {
            try
            {
                Console.WriteLine($"Throw with ex {withEx}");
                this.RethrowException(withEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ex inner message {ex.Message}");
                Console.WriteLine($"ex stack trace {ex.StackTrace}");
            }
        }
    }
}