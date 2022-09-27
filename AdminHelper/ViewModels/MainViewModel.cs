using AdminHelper.ViewModels.Shared;
using System.Threading.Tasks;

namespace AdminHelper.ViewModels
{
    //TODO: 4
    //Главный класс VM приложения, здесь хранятся данные для главного окна (MainWindow)
    public class MainViewModel : ViewModelBase
    {
        //С помощью DI получаем класс LoadingViewModel
        public MainViewModel(LoadingViewModel loadingViewModel)
        {
            _loadingViewModel = loadingViewModel;
            CurrentViewModel = this;
            Title = @"Театр ""На левом берегу""";
        }

        private readonly LoadingViewModel _loadingViewModel;

        private string? _title;
        private ViewModelBase? _currentViewModel;

        public string? Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }
        //От этого свойства зависит что будет отображаться в главной части окна приложения,
        //чтобы понять что отображать, выполняется сверка типа класса VM и V в файлах:
        //              Views/EntitiesViews/EntitiesView,
        //              Views/EntityViews/EntityView,
        //              MainWindow 
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel!;
            set => SetField(ref _currentViewModel, value);
        } 

        //Метод нужен для показа процесса загрузки извне
        public void ChangeToLoading()
        {
            CurrentViewModel = _loadingViewModel;
        }

        //Асинхронный метод смены отображения (применяется для долгих операций)
        public async void ChangeContent(object? obj)
        {
            await Task.Run(() =>
            {
                var viewModel = (ViewModelBase)obj!;
                CurrentViewModel = viewModel;
            });
        }
        //Проверка на возможность смены содержимого классом представленным в переменной arg
        public bool CanChangeContent(object? arg) => 
            arg is ViewModelBase viewModel &&
            viewModel != CurrentViewModel;
    }
}
