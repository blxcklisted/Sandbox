using HackerearthApiLib.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerearthApiLib;

public static class HackerearthApi
{
    static string CLIENT_SECRET = "1e5671f9af374f9a90b52cbee597684f104a5c00";
    static string CODE_EVALUATION_URL = "https://api.hackerearth.com/v4/partner/code-evaluation/submissions/";

    public static async Task<JsonResponse> Compile(InputModel inputModel)
    {
        using var client = new HttpClient();
        string requestBody = GetRequestBody(inputModel);

        using var cont = new StringContent(requestBody);

        cont.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        client.DefaultRequestHeaders.Add("client-secret", CLIENT_SECRET);

        using var response = await client.PostAsync(CODE_EVALUATION_URL, cont);

        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<JsonResponse>(await response.Content.ReadAsStringAsync())!;

        return new JsonResponse();
    }

    public static async Task<JsonResponse> GetCompilationResult(string statusUpdateUrl)
    {
        using var client = new HttpClient();
        
        client.DefaultRequestHeaders.Add("client-secret", CLIENT_SECRET);

        using var response = await client.GetAsync(statusUpdateUrl);

        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<JsonResponse>(await response.Content.ReadAsStringAsync())!;

        return new JsonResponse();
    }

    public static async Task<string> GetCompilationOutput(string outputUrl)
    {
        using var client = new HttpClient();
        
        client.DefaultRequestHeaders.Add("client-secret", CLIENT_SECRET);

        using var response = await client.GetAsync(outputUrl);

        return await response.Content.ReadAsStringAsync();
    }

    private static string GetRequestBody(InputModel inputModel) => $@"
    {{
        ""lang"": ""{inputModel.Language}"",
        ""source"": ""{inputModel.Source}"",
        ""input"": ""{inputModel.Input}"",
        ""memory_limit"": {inputModel.MemoryLimit},
        ""time_limit"": {inputModel.TimeLimit},
        ""id"": ""{inputModel.Id}"",
        ""callback"": ""{inputModel.CallBack}""
    }}";

}
