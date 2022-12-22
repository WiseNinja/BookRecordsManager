using AutoMapper;
using BookRecordsManager.Application.Commands.SaveBookRecords;
using BookRecordsManager.Application.Interfaces;
using BookRecordsManager.Application.Interfaces.Persistence;
using BookRecordsManager.Application.Queries.ReadInputData;
using BookRecordsManager.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookRecordsManager.Application.Commands.FormatBookRecords
{
    internal class FormatBookRecordsCommandHandler : IRequestHandler<FormatBookRecordsCommand, FormatBookRecordsCommandResponse>
    {
        private readonly IInputDataFormatter _inputDataFormatter;
        private readonly ILogger<FormatBookRecordsCommandHandler> _logger;

        public FormatBookRecordsCommandHandler(IInputDataFormatter inputDataFormatter, ILogger<FormatBookRecordsCommandHandler> logger)
        {
            _inputDataFormatter = inputDataFormatter;
            _logger = logger;
        }

        public async Task<FormatBookRecordsCommandResponse> Handle(FormatBookRecordsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var formattedBookRecords = await _inputDataFormatter.FormatInputData(request.BookRecordsToFormat);
                return new FormatBookRecordsCommandResponse(true, formattedBookRecords);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception has occured during Book Records formatting, details: {ex}");
                return new FormatBookRecordsCommandResponse(false, ex.Message);
            }
        }
    }
}