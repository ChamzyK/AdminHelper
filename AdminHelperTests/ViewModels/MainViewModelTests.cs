using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdminHelper.ViewModels.Shared;

namespace AdminHelper.ViewModels.Tests
{
    [TestClass()]
    public class MainViewModelTests
    {
        [TestMethod()]
        public void ChangeToLoadingTest()
        {
            var loadingViewModel = new LoadingViewModel();
            var mainViewModel = new MainViewModel(loadingViewModel);

            mainViewModel.ChangeToLoading();

            Assert.AreEqual(loadingViewModel, mainViewModel.CurrentViewModel);
        }

        [TestMethod()]
        public void ChangeContentTest()
        {
            var mainViewModel = new MainViewModel(new LoadingViewModel());
            var viewModel = new ExceptionViewModel(mainViewModel);

            mainViewModel.ChangeContent(viewModel);

            Assert.AreEqual(viewModel, mainViewModel.CurrentViewModel);
        }

        [TestMethod()]
        public void CanChangeContentTest()
        {
            var mainViewModel = new MainViewModel(new LoadingViewModel());
            var viewModel = new ExceptionViewModel(mainViewModel);

            var result = mainViewModel.CanChangeContent(viewModel);

            Assert.IsTrue(result);
        }
    }
}