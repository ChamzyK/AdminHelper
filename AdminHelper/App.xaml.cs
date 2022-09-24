using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using AdminHelper.Models.DbContexts;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.Shared;

namespace AdminHelper;

public partial class App : Application
{
    private static IHost? _host;
    public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

    public static IServiceProvider Services => Host.Services;

    internal static void ConfigureServices(HostBuilderContext _, IServiceCollection services) =>
        services.AddAdminHelperDbContext()
            .AddRepositories()
            .AddViewModels();

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