using AutoMapper;
using BookRecordsManager.Application.Commands.FormatBookRecords;
using BookRecordsManager.Application.Interfaces.Persistence;
using BookRecordsManager.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookRecordsManager.Application.Commands.SaveBookRecords
{
    internal class SaveBookRecordsCommandHandler : IRequestHandler<SaveBookRecordsCommand, SaveBookRecordsCommandResponse>
    {
        private readonly IBookRecordsRepository _bookRecordsRepository;
        private readonly ILogger<SaveBookRecordsCommandHandler> _logger;
        private readonly IMapper _mapper;

        public SaveBookRecordsCommandHandler(IMapper mapper, IBookRecordsRepository bookRecordsRepository, ILogger<SaveBookRecordsCommandHandler> logger)
        {
            _mapper = mapper;
            _bookRecordsRepository = bookRecordsRepository;
            _logger = logger;
        }
 
        public async Task<SaveBookRecordsCommandResponse> Handle(SaveBookRecordsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bookRecords = _mapper.Map<List<BookRecord>>(request.BookRecordsToSave);
                await _bookRecordsRepository.SaveBookRecordsAsync(bookRecords);
                return new SaveBookRecordsCommandResponse(true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred during saving of Book Records, details: {ex}");
                return new SaveBookRecordsCommandResponse(false, ex.Message);
            }
        }
    }
}
