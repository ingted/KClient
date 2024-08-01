namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbSessionNotFoundException : KbExceptionBase
    {
        public KbSessionNotFoundException()
        {
            Severity = KbConstants.KbLogSeverity.Warning;
        }

        public KbSessionNotFoundException(string message)
            : base($"Session not found: {message}.")
        {
            Severity = KbConstants.KbLogSeverity.Warning;
        }
    }
}
