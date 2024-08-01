namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbAssertException : KbExceptionBase
    {
        public KbAssertException()
        {
        }

        public KbAssertException(string message)
            : base($"Assert exception: {message}.")

        {
        }
    }
}
