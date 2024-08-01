namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbFatalException : KbExceptionBase
    {
        public KbFatalException()
        {
        }

        public KbFatalException(string? message)
            : base($"Fatal exception: {message}.")

        {
        }
    }
}
