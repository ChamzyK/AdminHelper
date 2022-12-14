using AdminHelper.Infrastructure.Commands.Base;
using System;

namespace AdminHelper.Infrastructure.Commands
{
    //TODO: 9 
    //Еще одна стандартная реализация паттерна комманда, только здесь что надо выполнять и условие выполнения задается при создании(т.е. в другом месте)
    internal class RelayCommand : CommandBase
    {
        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;

        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            this._execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this._canExecute = canExecute;
        }

        protected override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;
        protected override void Execute(object? parameter) => _execute(parameter);
    }
}
