namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbInvalidArgumentException : KbExceptionBase
    {
        public KbInvalidArgumentException()
        {
        }

        public KbInvalidArgumentException(string message)
            : base($"Invalid argument exception: {message}.")

        {
        }
    }
}
