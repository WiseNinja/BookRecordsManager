using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecordsManager.Application.Interfaces.Persistence;
using BookRecordsManager.Domain.Entities;
using CsvHelper.Configuration;
using CsvHelper;

namespace BookRecordsManager.Persistence.Repositories
{
    public class BookRecordsRepository : IBookRecordsRepository
    {
        public async Task SaveBookRecordsAsync(List<BookRecord> bookRecords)
        {
            try
            {
                var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                {
                    HasHeaderRecord = true,
                    Delimiter = ",",
                    Encoding = Encoding.UTF8
                };
                await using var writer = new StreamWriter("saved_book_records.csv");
                await using var csvWriter = new CsvWriter(writer, csvConfig);

                csvWriter.WriteHeader<BookRecord>();
                await csvWriter.NextRecordAsync();
                await csvWriter.WriteRecordsAsync(bookRecords.OrderBy(x => x.Title));
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving book records", ex);
            }
        }
    }
}
