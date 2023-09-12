using Sandbox.Services;

namespace Sandbox.Commands;

public class NavigateCommand : CommandBase
{
    private NavigationService navigationService;

    public NavigateCommand(NavigationService navigationService) => this.navigationService = navigationService;

    public override void Execute(object? parameter) => 
        navigationService.Navigate();
}
