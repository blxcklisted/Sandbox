using Newtonsoft.Json;

namespace HackerearthApiLib.Models;

public class JsonResponse
{
    [JsonProperty("he_id")]
    public string HeId { get; set; }

    [JsonProperty("request_status")]
    public RequestStatus RequestStatus { get; set; }

    [JsonProperty("status_update_url")]
    public string StatusUpdateUrl { get; set; }

    [JsonProperty("result")]
    public Result Result { get; set; }
}