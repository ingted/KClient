﻿namespace NTDLS.Katzebase.Client.Exceptions
{
    public class KbAssertException : KbExceptionBase
    {
        public KbAssertException()
        {
            LogSeverity = KbConstants.KbLogSeverity.Error;
        }

        public KbAssertException(string message)
            : base($"Assert exception: {message}.")
        {
            LogSeverity = KbConstants.KbLogSeverity.Error;
        }
    }
}
