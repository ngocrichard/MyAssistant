using FileIconExtraction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAssistant.Services;

namespace MyAssistant.Test.TestMainProject
{
    [TestClass]
    public class Test_FileIconService
    {
        public FileIconService FileIconService;

        public Test_FileIconService()
        {
            FileIconService = new FileIconService(new FileIconExtractService());
        }

        public const string SOURCE_PATH = @"ForTesting\dummy_for_Test_FileIconService.txt";
        public const string TARGET_PATH = @"dummy_for_Test_FileIconService.txt";

        [TestMethod]
        [DeploymentItem(SOURCE_PATH)]
        [DataRow(TARGET_PATH, 64)]
        public void Test_GetImage_DummyDeploymentFile_ShouldReturnNotNull(string filePath, int iconSize)
        {
            // Act
            var output = FileIconService.GetIcon(filePath, iconSize);

            // Assert
            Assert.IsNotNull(output);
        }
    }
}
