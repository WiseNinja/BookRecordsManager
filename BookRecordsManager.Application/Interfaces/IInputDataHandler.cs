using BookRecordsManager.Application.Queries.ReadInputData;
using BookRecordsManager.Domain.Entities;

namespace BookRecordsManager.Application.Interfaces
{
    public interface IInputDataHandler
    {
        Task<List<BookRecordVm>> ReadInputDataAsync();
    }
}
