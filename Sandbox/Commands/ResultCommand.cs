using HackerearthApiLib.Models;
using Sandbox.Services;

namespace Sandbox.Commands;

class ResultCommand : CommandBase
{
    private readonly InputModel inputModel;
    private readonly NavigationService resultViewNavigationService;

    public ResultCommand(InputModel inputModel, NavigationService resultViewNavigationService)
    {
        this.inputModel = inputModel;
        this.resultViewNavigationService = resultViewNavigationService;
    }

    public override void Execute(object? parameter) => 
        resultViewNavigationService.Navigate();
}
