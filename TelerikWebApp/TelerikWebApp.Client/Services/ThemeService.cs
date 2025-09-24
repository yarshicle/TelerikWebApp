using Microsoft.JSInterop;

namespace TelerikWebApp.Client.Services;

public enum Theme
{
    MaterialLight,
    MaterialDark
}

public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;
    private Theme _currentTheme = Theme.MaterialDark; // Default to current theme

    public event Action<Theme>? ThemeChanged;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public Theme CurrentTheme => _currentTheme;

    public async Task SetThemeAsync(Theme theme)
    {
        if (_currentTheme == theme) return;

        _currentTheme = theme;

        var themeUrl = GetThemeUrl(theme);
        await _jsRuntime.InvokeVoidAsync("setTelerikTheme", themeUrl);

        // Apply CSS custom properties for comprehensive theming
        await _jsRuntime.InvokeVoidAsync("applyAppTheme", GetThemeClass(theme));

        ThemeChanged?.Invoke(theme);
    }

    public async Task InitializeAsync()
    {
        // Set initial theme
        var themeUrl = GetThemeUrl(_currentTheme);
        await _jsRuntime.InvokeVoidAsync("setTelerikTheme", themeUrl);
        await _jsRuntime.InvokeVoidAsync("applyAppTheme", GetThemeClass(_currentTheme));
    }

    private static string GetThemeUrl(Theme theme)
    {
        return theme switch
        {
            Theme.MaterialLight => "https://blazor.cdn.telerik.com/blazor/11.1.1/kendo-theme-material/swatches/material-main.css",
            Theme.MaterialDark => "https://blazor.cdn.telerik.com/blazor/11.1.1/kendo-theme-material/swatches/material-main-dark.css",
            _ => "https://blazor.cdn.telerik.com/blazor/11.1.1/kendo-theme-material/swatches/material-main-dark.css"
        };
    }

    private static string GetThemeClass(Theme theme)
    {
        return theme switch
        {
            Theme.MaterialLight => "theme-light",
            Theme.MaterialDark => "theme-dark",
            _ => "theme-dark"
        };
    }
}