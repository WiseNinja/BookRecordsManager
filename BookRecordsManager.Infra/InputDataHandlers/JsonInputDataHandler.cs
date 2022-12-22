using BookRecordsManager.Application;
using BookRecordsManager.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NJsonSchema;

namespace BookRecordsManager.Infra.InputDataHandlers
{
    public class JsonInputDataHandler : IInputDataHandler
    {
        private readonly ILogger<JsonInputDataHandler> _logger;

        public JsonInputDataHandler(ILogger<JsonInputDataHandler> logger)
        {
            _logger = logger;
        }
        public async Task<List<BookRecordVm>> ReadInputDataAsync()
        {
            try
            {
                using StreamReader r = new StreamReader("books.json");
                string json = await r.ReadToEndAsync();
                var jsonSchema = await JsonSchema.FromFileAsync("schema.json");
                var jsonValidationErrors = jsonSchema.Validate(json);
                if (jsonValidationErrors.Count > 0)
                {
                    foreach (var validationError in jsonValidationErrors)
                    {
                        _logger.LogError($"Error occurred during json input validation, details: {validationError}");
                    }

                    throw new Exception("Error occurred during json input validation");
                }
                return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<BookRecordVm>>(json,
                    new JsonSerializerSettings
                    {
                        DateFormatString = "yyyy-MM-dd"
                    }));
            }
            catch (Exception e)
            {
                throw new Exception("Error reading input data", e);
            }

        }
    }
}
