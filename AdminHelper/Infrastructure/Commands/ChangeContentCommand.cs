using AdminHelper.Infrastructure.Commands.Base;
using AdminHelper.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminHelper.Infrastructure.Commands
{
    public class ChangeContentCommand : CommandBase
    {
        private readonly MainViewModel _mainViewModel = App.Services.GetRequiredService<MainViewModel>();
        protected override void Execute(object? parameter) => _mainViewModel.ChangeContent(parameter);
        protected override bool CanExecute(object? parameter) => _mainViewModel.CanChangeContent(parameter);
    }
}
