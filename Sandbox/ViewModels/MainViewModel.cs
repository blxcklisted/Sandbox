using HackerearthApiLib.Models;
using Sandbox.Commands;
using Sandbox.Stores;
using System.Windows.Input;

namespace Sandbox.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly InputModel inputModel;
    private readonly NavigationStore navigationStore;
    private bool isLight;
    private int time = 5;
    private int memory = 243232;
    private string input = "";

    public int Time
    {
        get => time;
        set
        {
            time = value;
            inputModel.TimeLimit = value;
            OnPropertyChanged();
        }
    }
    public int Memory
    {
        get => memory;
        set
        {
            memory = value;
            inputModel.MemoryLimit = value;
            OnPropertyChanged();
        }
    }
    public string Input
    {
        get => input;
        set
        {
            input = value;
            inputModel.Input = value;
            OnPropertyChanged();
        }
    }
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
        this.inputModel = inputModel;
        this.navigationStore = navigationStore;

        Time = 5;
        Memory = 243232;
        Input = "";
        this.inputModel.Id = "client001";
        this.inputModel.CallBack = "https://client.com/callback/";

        navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

        CloseCommand = new CloseCommand();

        ChangeToPython = new ChangeToPython(inputModel);
        ChangeToC = new ChangeToC(inputModel);
        ChangeToCpp = new ChangeToCpp(inputModel);
        ChangeToCsharp = new ChangeToCsharp(inputModel);
        ChangeToJava = new ChangeToJava(inputModel);
        ChangeToSwift = new ChangeToSwift(inputModel);
        ChangeToPhp = new ChangeToPhp(inputModel);
    }



    private void ChangeTheme()
    {
        ChangeThemeCommand = new ChangeThemeCommand(isLight);
        ChangeThemeCommand.Execute(this);
    }

    public ICommand CloseCommand { get; set; }
    public ICommand ChangeThemeCommand { get; set; }

    public ICommand ChangeToPython { get; set; }
    public ICommand ChangeToC { get; set; }
    public ICommand ChangeToCpp { get; set; }
    public ICommand ChangeToCsharp { get; set; }
    public ICommand ChangeToJava { get; set; }
    public ICommand ChangeToSwift { get; set; }
    public ICommand ChangeToPhp { get; set; }
    private void OnCurrentViewModelChanged() =>
        OnPropertyChanged(nameof(CurrentViewModel));

}
