using AdminHelper.Infrastructure.Commands;
using System;
using System.Windows.Input;

namespace AdminHelper.ViewModels.Shared
{
    public class ExceptionViewModel : ViewModelBase
    {
		private string? _exceptionText;
		private ICommand? _returnCommand;
		private MainViewModel _mainViewModel;

		public string? ExceptionText
		{
			get { return _exceptionText; }
			set { SetField(ref _exceptionText, value); }
		}
		public ICommand? ReturnCommand
		{
			get => _returnCommand;
			set => SetField(ref _returnCommand, value);
		}

		public ExceptionViewModel(MainViewModel mainViewModel)
		{
            _mainViewModel = mainViewModel;
			ExceptionText = "Ошибка!";
			ReturnCommand = new RelayCommand(Return);
		}

		private void Return(object? obj)
		{
			_mainViewModel.CurrentViewModel = _mainViewModel;

        }
	}
}
