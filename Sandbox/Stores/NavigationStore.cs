using Sandbox.ViewModels;
using System;

namespace Sandbox.Stores;
public class NavigationStore
{
    private ViewModelBase currentViewModel;
    public ViewModelBase CurrentViewModel
    {
        get => currentViewModel;
        set
        {
            currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    private void OnCurrentViewModelChanged() =>
        CurrentViewModelChanged?.Invoke();

    public event Action CurrentViewModelChanged;
}
