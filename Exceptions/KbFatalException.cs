namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbFatalException : KbExceptionBase
    {
        public KbFatalException()
        {
            Severity = KbConstants.KbLogSeverity.Fatal;
        }

        public KbFatalException(string? message)
            : base($"Fatal exception: {message}.")
        {
            Severity = KbConstants.KbLogSeverity.Fatal;
        }
    }
}
