namespace Playground.Interfaces
{
    internal interface IHandleExceptions
    {
        void RethrowException(bool withEx);

        void ThrowException();
    }
}