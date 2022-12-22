using BookRecordsManager.Application.Interfaces;
using BookRecordsManager.Application.Queries.ReadInputData;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;

namespace BookRecordsManager.Application.Tests
{
    //TODO: add more unit tests as required
    public class ReadInputDataTests
    {
        public Mock<IInputDataHandler> _inputDataHandlerMock = new Mock<IInputDataHandler>();
        public Mock<IInputDataHandler> _badInputDataHandlerMock = new Mock<IInputDataHandler>();
        public Mock<ILogger<ReadInputDataQueryHandler>> logger = new Mock<ILogger<ReadInputDataQueryHandler>>();
        public ReadInputDataTests()
        {
            _inputDataHandlerMock.Setup(x => x.ReadInputDataAsync()).ReturnsAsync(new List<BookRecordVm>
            {
                new BookRecordVm
                {
                    Author = "xx",
                    Title = "yy",
                    Genre = "zz",
                    Description = "aa",
                    Price = 1,
                    Id = "abcd",
                    PublishDate = new DateTime(2020, 1, 1)

                }
            });
            _badInputDataHandlerMock.Setup(x => x.ReadInputDataAsync()).ThrowsAsync(new Exception("Exception"));
        }
        
        [Fact]
        public async void Successful_Data_Read_Test()
        {
            ReadInputDataQuery query = new ReadInputDataQuery();
            ReadInputDataQueryHandler readInputDataQueryHandler = new ReadInputDataQueryHandler(_inputDataHandlerMock.Object, logger.Object);
            var dummyResponse = await readInputDataQueryHandler.Handle(query, CancellationToken.None);
            Assert.True(dummyResponse.Success);
            Assert.NotNull(dummyResponse.BookRecords);
        }

        [Fact]
        public async void Bad_Data_Read_Test()
        {
            ReadInputDataQuery query = new ReadInputDataQuery();
            ReadInputDataQueryHandler readInputDataQueryHandler = new ReadInputDataQueryHandler(_badInputDataHandlerMock.Object, logger.Object);
            var dummyResponse = await readInputDataQueryHandler.Handle(query, CancellationToken.None);
            Assert.Null(dummyResponse.BookRecords);
            Assert.NotNull(dummyResponse.ErrorMessage);
            Assert.False(dummyResponse.Success);
        }
    }
}