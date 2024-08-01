namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbFatalException : KbExceptionBase
    {
        public KbFatalException()
        {
            LogSeverity = KbConstants.KbLogSeverity.Fatal;
        }

        public KbFatalException(string? message)
            : base($"Fatal exception: {message}.")
        {
            LogSeverity = KbConstants.KbLogSeverity.Fatal;
        }
    }
}
