namespace NTDLS.Katzebase.Client.Payloads
{
    /// <summary>
    /// KbQueryResult is used to return a collection of field-sets and their associated row values.
    /// </summary>
    public class KbQueryResultCollection : KbBaseActionResponse
    {
        public new double Duration => Collection.Sum(o => o.Duration);

        public List<KbQueryDocumentListResult> Collection { get; set; } = new();

        private bool _success = true;
        public new bool Success
        {
            get => _success && Collection.All(o => o.Success);
            set => _success = value;
        }

        public KbQueryDocumentListResult AddNew()
        {
            var result = new KbQueryDocumentListResult();
            Collection.Add(result);
            return result;
        }

        public void Add(KbQueryResultCollection result)
        {
            Collection.AddRange(result.Collection);
        }

        public void Add(KbQueryDocumentListResult result)
        {
            Collection.Add(result);
        }

        public static KbQueryDocumentListResult FromActionResponse(KbActionResponse actionResponse)
        {
            return new KbQueryDocumentListResult()
            {
                RowCount = actionResponse.RowCount,
                Success = actionResponse.Success,
                ExceptionText = actionResponse.ExceptionText,
                Metrics = actionResponse.Metrics,
                Explanation = actionResponse.Explanation,
            };
        }
    }
}
