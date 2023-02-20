namespace Homework7
{
    internal class ContactDoesNotExistException : Exception
    {
        public ContactDoesNotExistException(string message)
            : base(message)
        {
        }
    }
}
