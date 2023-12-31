﻿using System;
using System.Windows;

namespace Sandbox.Themes;

public static class ThemesController
{
    public static ThemeTypes CurrentTheme { get; set; }

    public enum ThemeTypes
    {
        Light, Dark
    }

    public static ResourceDictionary ThemeDictionary
    {
        get => Application.Current.Resources.MergedDictionaries[0];
        set => Application.Current.Resources.MergedDictionaries[0] = value;
    }

    private static void ChangeTheme(Uri uri) => ThemeDictionary = new ResourceDictionary() { Source = uri };

    public static void SetTheme(ThemeTypes theme)
    {
        string themeName = null!;
        CurrentTheme = theme;
        switch (theme)
        {
            case ThemeTypes.Dark: themeName = "DarkTheme"; break;
            case ThemeTypes.Light: themeName = "LightTheme"; break;
        }

        if (!string.IsNullOrEmpty(themeName))
            ChangeTheme(new Uri($"Themes/{themeName}.xaml", UriKind.Relative));
    }
}
