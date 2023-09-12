using HackerearthApiLib.Models;

namespace Sandbox.Commands;

public class ChangeToCsharp : CommandBase
{
    private readonly InputModel inputModel;

    public ChangeToCsharp(InputModel inputModel) => this.inputModel = inputModel;
    public override void Execute(object? parameter) => inputModel.Language = "CSHARP";
}
public class ChangeToCpp : CommandBase
{
    private readonly InputModel inputModel;

    public ChangeToCpp(InputModel inputModel) => this.inputModel = inputModel;
    public override void Execute(object? parameter) => inputModel.Language = "CPP17";
}

public class ChangeToC : CommandBase
{
    private readonly InputModel inputModel;

    public ChangeToC(InputModel inputModel) => this.inputModel = inputModel;
    public override void Execute(object? parameter) => inputModel.Language = "C";
}
public class ChangeToPython : CommandBase
{
    private readonly InputModel inputModel;

    public ChangeToPython(InputModel inputModel) => this.inputModel = inputModel;
    public override void Execute(object? parameter) => inputModel.Language = "PYTHON3_8";
}
public class ChangeToJava : CommandBase
{
    private readonly InputModel inputModel;

    public ChangeToJava(InputModel inputModel) => this.inputModel = inputModel; 
    public override void Execute(object? parameter) => inputModel.Language = "JAVA14";
}
public class ChangeToSwift : CommandBase
{
    private readonly InputModel inputModel;

    public ChangeToSwift(InputModel inputModel) => this.inputModel = inputModel; 
    public override void Execute(object? parameter) => inputModel.Language = "SWIFT";
}
public class ChangeToPhp : CommandBase
{
    private readonly InputModel inputModel;

    public ChangeToPhp(InputModel inputModel) => this.inputModel = inputModel; 
    public override void Execute(object? parameter) => inputModel.Language = "PHP";
}