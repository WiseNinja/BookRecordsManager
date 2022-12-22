using BookRecordsManager.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookRecordsManager.Application.Queries.ReadInputData
{
    public class ReadInputDataQueryHandler : IRequestHandler<ReadInputDataQuery, ReadInputDataQueryResponse>
    {
        private readonly IInputDataHandler _inputDataHandler;
        private readonly ILogger<ReadInputDataQueryHandler> _logger;

        public ReadInputDataQueryHandler(IInputDataHandler inputDataHandler, ILogger<ReadInputDataQueryHandler> logger)
        {
            _inputDataHandler = inputDataHandler;
            _logger = logger;
        }


        public async Task<ReadInputDataQueryResponse> Handle(ReadInputDataQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var inputData = (await _inputDataHandler.ReadInputDataAsync());
                return new ReadInputDataQueryResponse(true, inputData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading input data");
                return new ReadInputDataQueryResponse(false, ex.Message);
            }

        }
    }
}
