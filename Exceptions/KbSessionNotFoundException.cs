namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbSessionNotFoundException : KbExceptionBase
    {
        public KbSessionNotFoundException()
        {
        }

        public KbSessionNotFoundException(string message)
            : base($"Session not found: {message}.")

        {
        }
    }
}
