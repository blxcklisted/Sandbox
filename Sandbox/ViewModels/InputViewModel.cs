using HackerearthApiLib.Models;
using Sandbox.Commands;
using Sandbox.Services;
using System.Windows.Input;

namespace Sandbox.ViewModels;

public class InputViewModel : ViewModelBase
{
    private string text;
    private readonly InputModel inputModel;
    private readonly NavigationService resultViewNavigationService;

    public ICommand ResultCommand { get; set; }
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

        ResultCommand = new ResultCommand(inputModel, resultViewNavigationService);
        this.resultViewNavigationService = resultViewNavigationService;

        if (!string.IsNullOrEmpty(inputModel.Source))
            Text = inputModel.Source;
    }
}
