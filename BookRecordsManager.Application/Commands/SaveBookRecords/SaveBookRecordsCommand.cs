using BookRecordsManager.Application.Queries.ReadInputData;
using MediatR;

namespace BookRecordsManager.Application.Commands.SaveBookRecords
{
    public class SaveBookRecordsCommand : IRequest<SaveBookRecordsCommandResponse>
    {
        public SaveBookRecordsCommand(List<BookRecordVm> bookRecordsToSave)
        {
            BookRecordsToSave = bookRecordsToSave;
        }
        
        public List<BookRecordVm> BookRecordsToSave { get; }
    }
}