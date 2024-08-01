namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbSessionNotFoundException : KbExceptionBase
    {
        public KbSessionNotFoundException()
        {
            LogSeverity = KbConstants.KbLogSeverity.Warning;
        }

        public KbSessionNotFoundException(string message)
            : base($"Session not found: {message}.")
        {
            LogSeverity = KbConstants.KbLogSeverity.Warning;
        }
    }
}
