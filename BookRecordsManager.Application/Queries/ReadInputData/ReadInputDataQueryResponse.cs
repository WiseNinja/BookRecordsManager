using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecordsManager.Application.Queries.ReadInputData
{
    public class ReadInputDataQueryResponse
    {
        public ReadInputDataQueryResponse(bool success, List<BookRecordVm> bookRecords)
        {
            Success = success;
            BookRecords = bookRecords;
        }

        public ReadInputDataQueryResponse(bool success)
        {
            Success = success;
        }
        public ReadInputDataQueryResponse(bool success, string errorMessage) : this(success)
        {
            ErrorMessage = errorMessage;
        }
        public List<BookRecordVm>? BookRecords { get; }
        public bool Success { get; }
        public string? ErrorMessage { get; }
    }
}
