using HackerearthApiLib;
using HackerearthApiLib.Models;
using Sandbox.Commands;
using Sandbox.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sandbox.ViewModels;

public class ResultViewModel : ViewModelBase
{
    private readonly InputModel inputModel;
    private string text;

    public ResultViewModel(InputModel inputModel, NavigationService inputViewNavigationService)
    {
        this.inputModel = inputModel;

        Task.Run( async () => 
        {
            Text = await CompileCode(inputModel);
        });

        ReturnCommand = new ReturnCommand(inputModel, inputViewNavigationService);
    }
        
    async Task<string> CompileCode(InputModel inputModel)
    {
        var compiling = await HackerearthApi.Compile(inputModel);
       
        var result = await HackerearthApi.GetCompilationResult(compiling.StatusUpdateUrl);

        return await HackerearthApi.GetCompilationOutput(result.Result.RunStatus.Output); 
    }
    public ICommand ReturnCommand { get; }
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
