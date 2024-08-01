namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbExceptionBase : Exception
    {
        public KbExceptionBase()
        {
        }

        public KbExceptionBase(string? message)
            : base(message)
        {
        }
    }
}
