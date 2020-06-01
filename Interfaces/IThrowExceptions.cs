namespace Playground.Interfaces
{
    internal interface IThrowExceptions
    {
        void RethrowException(bool withEx);

        void ThrowException();
    }
}