namespace Homework7
{
    internal class NotACommandException : Exception
    {
        public NotACommandException(string message)
            : base(message)
        {
        }
    }
}
