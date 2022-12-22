using Newtonsoft.Json;

namespace BookRecordsManager.Application;

public class BookRecordVm
{
    [JsonProperty("@id")]
    public string Id { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public double Price { get; set; }

    [JsonProperty("publish_date")]
    public DateTime PublishDate { get; set; }
    public string Description { get; set; }
}