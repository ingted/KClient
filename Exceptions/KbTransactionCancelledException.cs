namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbTransactionCancelledException : KbExceptionBase
    {
        public KbTransactionCancelledException()
        {
        }

        public KbTransactionCancelledException(string message)
            : base($"Transaction Cancelled: {message}.")
        {
        }
    }
}
