using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookRecordsManager.Application;
using BookRecordsManager.Application.Commands.FormatBookRecords;
using BookRecordsManager.Application.Commands.SaveBookRecords;
using BookRecordsManager.Application.Queries.ReadInputData;
using MediatR;
using BookRecordsManager.Infra;
using BookRecordsManager.Persistence;
using Microsoft.Extensions.Logging;

Console.WriteLine("Starting BookRecordsManager");

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddApplicationServices()
            .AddPersistenceServices()
            .AddInfrastructureServices()
            .AddLogging(x => x.AddConsole()))
    .Build();

var serviceScope = host.Services.CreateScope();
var serviceProvider = serviceScope.ServiceProvider;
var mediator = serviceProvider.GetRequiredService<IMediator>();

ReadInputDataQueryResponse readInputDataQueryResponse = await ReadInputData();
if (readInputDataQueryResponse.Success)
{
    Console.WriteLine("Finished getting the new Book Records to save");
}
else
{
    Console.WriteLine("There were errors when trying to retrieve the Book Records to save, please consult the log for more details");
    return;
}

var formatBookRecordsCommandResponse = await FormatBookRecords(readInputDataQueryResponse.BookRecords);
if (formatBookRecordsCommandResponse.Success)
{
    Console.WriteLine("Finished formatting the new Book Records");
}
else
{
    Console.WriteLine("There were errors when trying to format the Book Records, please consult the log for more details");
    return;
}


var saveBookRecordsCommandResponse = await SaveBookRecords(formatBookRecordsCommandResponse.FormattedBookRecords);
if (saveBookRecordsCommandResponse.Success)
{
    Console.WriteLine("Finished saving the Book Records");
}
else
{
    Console.WriteLine("There were errors when trying to save the Book Records, please consult the log for more details");
}

Console.WriteLine("Press any key to exit");
Console.ReadKey();

async Task<ReadInputDataQueryResponse> ReadInputData()
{
    return await mediator.Send(new ReadInputDataQuery());
}

async Task<FormatBookRecordsCommandResponse> FormatBookRecords(List<BookRecordVm> bookRecordsToFormat)
{
    return await mediator.Send(new FormatBookRecordsCommand(bookRecordsToFormat));
}

async Task<SaveBookRecordsCommandResponse> SaveBookRecords(List<BookRecordVm> bookRecordsToSave)
{
    return await mediator.Send(new SaveBookRecordsCommand(bookRecordsToSave));
}
