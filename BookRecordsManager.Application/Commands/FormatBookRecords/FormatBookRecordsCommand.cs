using MediatR;

namespace BookRecordsManager.Application.Commands.FormatBookRecords
{
    public class FormatBookRecordsCommand : IRequest<FormatBookRecordsCommandResponse>
    {
        public FormatBookRecordsCommand(List<BookRecordVm> bookRecordsToFormat)
        {
            BookRecordsToFormat = bookRecordsToFormat;
        }

        public List<BookRecordVm> BookRecordsToFormat { get; }
    }
}