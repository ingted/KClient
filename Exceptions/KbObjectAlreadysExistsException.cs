using static NTDLS.Katzebase.Client.KbConstants;

namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbObjectAlreadyExistsException : KbExceptionBase
    {
        public KbObjectAlreadyExistsException()
        {
            Severity = KbLogSeverity.Warning;
        }

        public KbObjectAlreadyExistsException(string? message)
            : base($"Object already exists exception: {message}.")

        {
            Severity = KbLogSeverity.Exception;
        }
    }
}
