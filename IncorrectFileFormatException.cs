namespace Homework7
{
    internal class IncorrectFileFormatException : Exception
    {
        public IncorrectFileFormatException(string message)
            : base(message)
        { 
        }
    }
}
