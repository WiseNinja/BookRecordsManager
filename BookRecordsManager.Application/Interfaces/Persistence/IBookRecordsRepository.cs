using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecordsManager.Domain.Entities;

namespace BookRecordsManager.Application.Interfaces.Persistence
{
    public interface IBookRecordsRepository
    {
        Task SaveBookRecordsAsync(List<BookRecord> bookRecords);
    }
}
