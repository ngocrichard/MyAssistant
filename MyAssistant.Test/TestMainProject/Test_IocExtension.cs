using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyAssistant.Test.TestMainProject
{
    [TestClass]
    public class Test_IocExtension
    {
        [TestMethod]
        public void Test_Get_Method_ShouldReturnResultOfMethodGetOfIoC()
        {
            // Arrange
            var expected = new object();
            IoC.GetInstance = (type, name) => expected; // Fake IoC

            // Act
            var output = IoCExtension.Get(typeof(object));

            // Assert
            Assert.AreSame(expected, output);
        }

        [TestMethod]
        public void Test_Get_Method_ShouldThrowArgumentNullException()
        {
            // Act
            Action action = () => IoCExtension.Get(null);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(action);
        }
    }
}
