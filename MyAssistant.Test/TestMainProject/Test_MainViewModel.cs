using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyAssistant.Services;
using MyAssistant.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAssistant.Test.TestMainProject
{
    [TestClass]
    public class Test_MainViewModel
    {
        public MainViewModel MainViewModel;
        public Mock<ITabsProvider> TabProviderFake;
        public Mock<IMainService> MainServiceStub;

        public List<Screen> TabsFake;

        [TestInitialize]
        public void Init()
        {
            // Setup stub and fake
            TabProviderFake = new Mock<ITabsProvider>();
            MainServiceStub = new Mock<IMainService>();
            MainViewModel = new MainViewModel(MainServiceStub.Object, TabProviderFake.Object);
        }

        [TestMethod]
        public async Task Test_SetupWindow_ShouldPerformAnimation()
        {
            // Act
            await MainViewModel.SetupWindow();

            // Assert
            MainServiceStub.Verify(x => x.PerformStateChangedAnimation(It.IsAny<MainViewModel>()));

        }
    }
}
