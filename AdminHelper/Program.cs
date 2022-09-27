using System;
using Microsoft.Extensions.Hosting;

namespace AdminHelper;

public static class Program
{
    //TODO:1
    //Переопределенная точка входа в приложение (стандартная точка входа была в: App.g.i.cs)
    //Создали свою точку входа чтобы вручную определить параметры запуска (в данном случае это нужно для добавление в проект возможности ВНЕДРЕНИИ ЗАВИСИМОСТЕЙ)
    [STAThread]//Указывается для точек входа (поточность)
    public static void Main(string[] args)
    {
        var app = new App(); //создаем десктопное приложение
        app.InitializeComponent(); // вызываем метод создающий компоненты (все окна и отображения)
        app.Run(); //запускаем приложение
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => //метод для создания хоста
        Host.CreateDefaultBuilder(args) //получаем класс ининциализатор хоста
            .ConfigureServices(App.ConfigureServices); //добавляем все сервисы к хосту
}