using Newtonsoft.Json;

namespace HackerearthApiLib.Models;

public class RequestStatus
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
}
