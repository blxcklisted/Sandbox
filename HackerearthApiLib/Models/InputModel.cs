namespace HackerearthApiLib.Models;

public class InputModel
{
    public string Language { get; set; }
    public string Source { get; set; }
    public string Input { get; set; }
    public int MemoryLimit { get; set; }
    public int TimeLimit { get; set; }
    public string Id { get; set; }
    public string CallBack { get; set; }

    public InputModel(string language, string source, string input = "", 
                        int memoryLimit = 243232, int timeLimit = 5, 
                        string id = "client001", string callBack = "https://client.com/callback/")
    {
        Language = language;
        Source = source;
        Input = input;
        MemoryLimit = memoryLimit;
        TimeLimit = timeLimit;
        Id = id;
        CallBack = callBack;
    }
}
