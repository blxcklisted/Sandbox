using System;
using System.Windows;

namespace Sandbox.Commands;

public class CloseCommand : CommandBase
{
    public override void Execute(object? parameter) => Application.Current.Shutdown();
}
