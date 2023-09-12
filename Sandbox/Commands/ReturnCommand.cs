using HackerearthApiLib.Models;
using Sandbox.Services;

namespace Sandbox.Commands;

public class ReturnCommand : CommandBase
{
    private readonly InputModel inputModel;
    private readonly NavigationService navigationService;

    public ReturnCommand(InputModel inputModel, NavigationService navigationService)
    {
        this.inputModel = inputModel;
        this.navigationService = navigationService;
    }
    public override void Execute(object? parameter) => navigationService.Navigate();
}
