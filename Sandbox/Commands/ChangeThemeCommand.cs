using Sandbox.Themes;

namespace Sandbox.Commands;

internal class ChangeThemeCommand : CommandBase
{
    private readonly bool isLight;

    public ChangeThemeCommand(bool IsLight)
    {
        isLight = IsLight;
    }

    public override void Execute(object? parameter)
    {
        if (isLight)
            ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
        else
            ThemesController.SetTheme(ThemesController.ThemeTypes.Light);

    }
}
