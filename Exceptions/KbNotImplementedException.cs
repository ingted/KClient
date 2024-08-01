namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbNotImplementedException : KbExceptionBase
    {
        public KbNotImplementedException()
        {
        }

        public KbNotImplementedException(string message)
            : base($"Not implemented exception: {message}.")

        {
        }
    }
}
