using System;
using System.Windows.Input;

namespace AdminHelper.Infrastructure.Commands.Base
{
    //TODO: 7 
    //Без паттерна Command паттерн MVVM не используется
    //здесь определена стандартная реализация которую можно найти везде в интернете
    //самое главное знать что здесь есть проверка выполнения (CanExecute) и вызов выполнения (Execute)
    public abstract class CommandBase : ICommand
    {
        private bool _executable = true;
        public bool Executable
        {
            get => _executable;
            set
            {
                if (Executable == value) return;
                _executable = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object? parameter) => Executable && CanExecute(parameter);
        void ICommand.Execute(object? parameter)
        {
            if (CanExecute(parameter))
            {
                Execute(parameter);
            }
        }

        protected virtual bool CanExecute(object? parameter) => true;
        protected abstract void Execute(object? parameter);
    }
}
