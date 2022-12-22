namespace BookRecordsManager.Application.Commands.SaveBookRecords
{
    public class SaveBookRecordsCommandResponse
    {
        public SaveBookRecordsCommandResponse(bool success)
        {
            Success = success;
        }
        public SaveBookRecordsCommandResponse(bool success, string errorMessage) : this(success)
        {
            ErrorMessage = errorMessage;
        }
       
        public bool Success { get; }
        public string? ErrorMessage { get; }
    }
}
