using HackerearthApiLib.Models;
using Sandbox.Services;
using Sandbox.Stores;
using Sandbox.ViewModels;
using Sandbox.Views;
using System.Windows;

namespace Sandbox;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly NavigationStore navigationStore;
    private readonly InputModel inputModel;

    public App()
    {
        this.navigationStore = new NavigationStore();
        this.inputModel = new InputModel();
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        navigationStore.CurrentViewModel = CreateInputViewModel();
        MainWindow = new MainView()
        {
            DataContext = new MainViewModel(inputModel, navigationStore)
        };

        MainWindow.Show();

        base.OnStartup(e);
    }

    private InputViewModel CreateInputViewModel() =>
                            new InputViewModel(inputModel, new NavigationService(navigationStore, CreateResultViewModel));

    private ResultViewModel CreateResultViewModel() => new ResultViewModel(inputModel);
    
}
