namespace NTDLS.Katzebase.Client.Payloads
{
    /// <summary>
    /// KbQueryResult is used to return a collection of field-sets and their associated row values.
    /// </summary>
    public class KbQueryResultCollection : KbBaseActionResponse
    {
        //public new List<KbQueryResultMessage> Messages => Collection.SelectMany(o => o.Messages).ToList();
        //public new Dictionary<KbTransactionWarning, HashSet<string>> Warnings => Collection.SelectMany(o => o.Warnings).ToDictionary(o => o.Key, o => o.Value);
        //public new int RowCount => Collection.Sum(o => o.RowCount);
        public new double Duration => Collection.Sum(o => o.Duration);

        public List<KbQueryDocumentListResult> Collection { get; set; } = new();

        private bool _success = true;
        public new bool Success
        {
            get
            {
                return _success && Collection.All(o => o.Success);
            }
            set
            {
                _success = value;
            }
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
