using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System;
using System.Windows;
using AdminHelper.ViewModels.Shared;

namespace AdminHelper;

public partial class App : Application
{
    public static string CurrentDir => Environment.CurrentDirectory;

    public static Window? FocusedWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsFocused);
    public static Window? ActiveWindow => Current.Windows.Cast<Window>().FirstOrDefault(w => w.IsActive);

    private static IHost? _host;
    public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

    public static IServiceProvider Services => Host.Services;

    internal static void ConfigureServices(HostBuilderContext _, IServiceCollection services) =>
        services.AddViewModels();

    protected override async void OnStartup(StartupEventArgs e)
    {
        var host = Host;

        base.OnStartup(e);

        await host.StartAsync();
    }
    protected override async void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);

        using (Host) await Host.StopAsync();
    }
}