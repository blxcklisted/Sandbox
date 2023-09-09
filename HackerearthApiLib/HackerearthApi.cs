using HackerearthApiLib.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerearthApiLib;

public class HackerearthApi
{
    string CLIENT_SECRET = "1e5671f9af374f9a90b52cbee597684f104a5c00";
    static string CODE_EVALUATION_URL = "https://api.hackerearth.com/v4/partner/code-evaluation/submissions/";

    async Task<JsonResponse> Post(InputModel inputModel)
    {
        using HttpClient client = new HttpClient();
        string requestBody = GetRequestBody(inputModel);

        using HttpContent cont = new StringContent(requestBody);
        using HttpResponseMessage response = await client.PostAsync(CODE_EVALUATION_URL, cont);

        cont.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        client.DefaultRequestHeaders.Add("client-secret", CLIENT_SECRET);

        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<JsonResponse>(await response.Content.ReadAsStringAsync())!;

        return new JsonResponse();

    }

    async Task<JsonResponse> Get(string statusUpdateUrl)
    {
        using HttpClient client = new HttpClient();
        using HttpResponseMessage response = await client.GetAsync(statusUpdateUrl);
        
        client.DefaultRequestHeaders.Add("client-secret", CLIENT_SECRET);

        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<JsonResponse>(await response.Content.ReadAsStringAsync())!;

        return new JsonResponse();
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
