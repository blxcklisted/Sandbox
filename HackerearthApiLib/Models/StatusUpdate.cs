using Newtonsoft.Json;

namespace HackerearthApiLib.Models;

public class StatusUpdate
{
    [JsonProperty("output")]
    public string Output { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("status_detail")]
    public string StatusDetail { get; set; }

    [JsonProperty("time_used")]
    public double TimeUsed { get; set; }

    [JsonProperty("memory_used")]
    public int MemoryUsed { get; set; }
}