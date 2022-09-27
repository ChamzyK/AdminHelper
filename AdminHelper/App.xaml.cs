using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using AdminHelper.Models.DbContexts;
using AdminHelper.Models.Repositories;
using AdminHelper.ViewModels.Shared;

namespace AdminHelper;

//TODO: 2
//В этом классе конфигурируем приложение
public partial class App : Application
{
    //Хост определяется в классе с точкой входа, а здесь он хранится
    private static IHost? _host;
    public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build(); //получение хоста

    public static IServiceProvider Services => Host.Services; //получение сервисов хоста, который определен выше

    internal static void ConfigureServices(HostBuilderContext _, IServiceCollection services) =>
        services.AddAdminHelperDbContext() //добавляем в сервисы базу данных
            .AddRepositories() //добавляем наши созданные классы репозитории в сервисы (классы-репозитории - классы для управления БД)
            .AddViewModels(); //добавляем все наши VM (нужны для работы паттерна MVVM)

    //Создание хоста, определение сервисов делается для включение механизма Внедрения зависимостей(Dependency Injection, DI)
    //По простому, DI нужен для того чтобы достать класс который зарегистрировали в сервисе через конструктор в любом месте кода
    //если посмотреть по проекту, то DI применяется везде (без DI реализация паттерна MVVM бессмыслена)

    //Здесь идет работа с хостом (можно не вникать)
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