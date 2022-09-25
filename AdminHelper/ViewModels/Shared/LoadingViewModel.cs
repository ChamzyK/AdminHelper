namespace AdminHelper.ViewModels.Shared
{
    public class LoadingViewModel : ViewModelBase
    {
        private string? _loadingText;

        public string? LoadingText 
        { 
            get => _loadingText; 
            set => SetField(ref _loadingText, value); 
        }

        public LoadingViewModel()
        {
            LoadingText = "Подождите, идет загрузка...";
        }
    }
}
