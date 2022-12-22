using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecordsManager.Application.Queries.ReadInputData;

namespace BookRecordsManager.Application.Interfaces
{
    public interface IInputDataFormatter
    {
        Task<List<BookRecordVm>> FormatInputData(List<BookRecordVm> bookRecords);
    }
}
