using BookRecordsManager.Application.Queries.ReadInputData;

namespace BookRecordsManager.Application.Commands.FormatBookRecords
{
    public class FormatBookRecordsCommandResponse
    {
        public FormatBookRecordsCommandResponse(bool success, List<BookRecordVm> formattedBookRecords)
        {
            Success = success;
            FormattedBookRecords = formattedBookRecords;
        }

        public FormatBookRecordsCommandResponse(bool success)
        {
            Success = success;
        }
        public FormatBookRecordsCommandResponse(bool success, string errorMessage) : this(success)
        {
            ErrorMessage = errorMessage;
        }
        public List<BookRecordVm>? FormattedBookRecords { get; }
        public bool Success { get; }
        public string? ErrorMessage { get; }
    }
}