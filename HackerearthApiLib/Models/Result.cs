using Newtonsoft.Json;

namespace HackerearthApiLib.Models;

public class Result
{
    [JsonProperty("compile_status")]
    public string CompileStatus { get; set; }

    [JsonProperty("run_status")]
    public StatusUpdate RunStatus { get; set; }
}