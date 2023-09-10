using HackerearthApiLib;
using HackerearthApiLib.Models;
using System.Threading.Tasks;

namespace Sandbox.ViewModels;

public class ResultViewModel : ViewModelBase
{
    private readonly InputModel inputModel;
    private string text;

    public ResultViewModel(InputModel inputModel)
    {
        this.inputModel = inputModel;

        Task.Run( async () => 
        {
            Text = await CompileCode(inputModel);
        });
    }



    async Task<string> CompileCode(InputModel inputModel)
    {
        var compiling = await HackerearthApi.Compile(inputModel);
        var result = await HackerearthApi.GetCompilationResult(compiling.StatusUpdateUrl);

        return await HackerearthApi.GetCompilationOutput(result.Result.RunStatus.Output);
    }
    public string Text 
    { 
        get => text;
        set
        {
            text = value;
            OnPropertyChanged();
        }
    }
}
