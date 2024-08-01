namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbNotImplementedException : KbExceptionBase
    {
        public KbNotImplementedException()
        {
            LogSeverity = KbConstants.KbLogSeverity.Fatal;
        }

        public KbNotImplementedException(string message)
            : base($"Not implemented exception: {message}.")
        {
            LogSeverity = KbConstants.KbLogSeverity.Fatal;
        }
    }
}
