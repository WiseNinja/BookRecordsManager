using BookRecordsManager.Application.Interfaces;
using BookRecordsManager.Application.Queries.ReadInputData;
using System.Linq;
using BookRecordsManager.Application;

namespace BookRecordsManager.Infra.InputDataFormatters
{
    public class DefaultInputDataFormatter : IInputDataFormatter
    {
        public async Task<List<BookRecordVm>> FormatInputData(List<BookRecordVm> bookRecords)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    foreach (var bookRecord in bookRecords)
                    {
                        bookRecord.Price = Math.Ceiling(bookRecord.Price);
                    }

                    bookRecords = bookRecords.Except(bookRecords.Where(x => x.Author.Contains("Peter"))).ToList();
                    bookRecords = bookRecords
                        .Except(bookRecords.Where(x => x.PublishDate.DayOfWeek == DayOfWeek.Saturday))
                        .ToList();
                    return bookRecords;
                });

            }
            catch (Exception ex)
            {
                throw new Exception("Error while formatting input data", ex);
            }
        }
    }

}
