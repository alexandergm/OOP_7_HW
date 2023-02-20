namespace Homework7
{
    internal class NumberDoesNotExistException : Exception
    {
        public NumberDoesNotExistException(string message)
            : base(message)
        {
        }
    }
}
