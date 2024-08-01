namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbDeadlockException : KbExceptionBase
    {
        public KbDeadlockException()
        {
        }

        public KbDeadlockException(string message)
            : base($"Deadlock exception: {message}.")
        {
        }

        public KbDeadlockException(string message, string explanation)
            : base($"Deadlock exception: {message}.\r\n\r\nExplanation:\r\n{explanation}")
        {
        }
    }
}
