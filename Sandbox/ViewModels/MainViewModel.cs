using HackerearthApiLib.Models;
using Sandbox.Commands;
using Sandbox.Stores;
using System.Windows.Input;

namespace Sandbox.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly NavigationStore navigationStore;
    private bool isLight;

    public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;
    public bool IsLight 
    {
        get => isLight;
        set
        {
            isLight = value;
            ChangeTheme();
            OnPropertyChanged();
        }
    }

    public MainViewModel(InputModel inputModel, NavigationStore navigationStore)
    {
        this.navigationStore = navigationStore;

        navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

        CloseCommand = new CloseCommand();
    }

    private void ChangeTheme()
    {
        ChangeThemeCommand = new ChangeThemeCommand(isLight);
        ChangeThemeCommand.Execute(this);
    }

    public ICommand CloseCommand { get; set; }
    public ICommand ChangeThemeCommand { get; set; }
    private void OnCurrentViewModelChanged() =>
        OnPropertyChanged(nameof(CurrentViewModel));

}
