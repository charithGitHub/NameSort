using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter.Utilities;
using NameSorter.BusinessContract;
using NameSorter.BusinessImplementation;

namespace NameSorter.UnitTest
{
    [TestClass]
    public class TestValidations
    {
        public TestValidations()
        {
            IApplication app = new Application();
            app.ResolveDependencies();
        }

        [TestMethod]
        public void TestValidateFileExtentionWithValidExtention()
        {
            Assert.IsTrue(string.IsNullOrEmpty(ValidateFileType(".txt")));
        }

        [TestMethod]
        public void TestValidateFileExtentionWithInValidExtention()
        {
            Assert.IsFalse(string.IsNullOrEmpty(ValidateFileType(".doc")));
        }

        [TestMethod]
        public void TestValidateFileExtentionWithUpperCaseExtention()
        {
            Assert.IsTrue(string.IsNullOrEmpty(ValidateFileType(".TXT")));
        }

        [TestMethod]
        public void TestValidateFileExtentionWithBlankExtention()
        {
            Assert.IsFalse(!string.IsNullOrEmpty(ValidateFileType("")));
        }

        private string ValidateFileType(string fileExt)
        {
            return DependencyFactory.Resolve<IValidator>().ValidateFileType(fileExt);
        }
    }
}
