using HackerearthApiLib.Models;
using Sandbox.Commands;
using Sandbox.Services;
using System.Windows.Input;

namespace Sandbox.ViewModels;

public class InputViewModel : ViewModelBase
{
    private string text;
    private readonly InputModel inputModel;

    public ICommand ResultCommand { get; }
    public string Text
    { 
        get => text;
        set
        { 
            text = value;
            inputModel.Source = value;
            OnPropertyChanged();
        }
    }
    public InputViewModel(InputModel inputModel, NavigationService resultViewNavigationService)
    {
        this.inputModel = inputModel;
        this.inputModel.Language = "PYTHON3_8";
        this.inputModel.Input = "";
        this.inputModel.TimeLimit = 5;
        this.inputModel.MemoryLimit = 246323;
        this.inputModel.Id = "client001";
        this.inputModel.CallBack = "https://client.com/callback/";
        

        ResultCommand = new ResultCommand(this.inputModel, resultViewNavigationService);
    }
}
