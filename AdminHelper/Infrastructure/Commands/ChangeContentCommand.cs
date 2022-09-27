using AdminHelper.Infrastructure.Commands.Base;
using AdminHelper.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.Infrastructure.Commands
{
    //TODO: 8
    //Явная реализация комманды, благодаря  файлу ресурсов Commands.xaml
    //эту реализацию можно достать в коде XAML
    public class ChangeContentCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel = App.Services.GetRequiredService<MainViewModel>(); //с помощью DI достаем класс MainViewModel

        protected override void Execute(object? parameter) => _mainViewModel.ChangeContent(parameter); //что надо делать
        protected override bool CanExecute(object? parameter) => _mainViewModel.CanChangeContent(parameter); // при каком условии возможно это сделать
    }
}
