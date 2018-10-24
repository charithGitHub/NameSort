using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter.BusinessImplementation;
using NameSorter.Utilities;
using NameSorter.BusinessContract;

namespace NameSorter.UnitTest
{

    [TestClass]
    public class TestTextFileProcessor
    {
        public TestTextFileProcessor()
        {
            IApplication app = new Application();
            app.ResolveDependencies();
        }

        [TestMethod]
        public void TestWithBlankText()
        {
            Assert.IsTrue(GetNames("").Count == 0);
        }

        [TestMethod]
        public void TestWithValidText()
        {
            Assert.IsTrue(GetNames("Dan Avantha\r\nSome Charith\r\nSam John\r\nCharith Rodrigo\r\nDonkey zeee").Count == 0);
        }

        [TestMethod]
        public void TestWithInValidText()
        {
            Assert.IsTrue(GetNames("Dan AvanthaSome Charith<nSam John>Charith Rodrigo-Donkey zeee").Count == 1);
        }

        private Stream GetMockText(string text)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(text);
            
            return new MemoryStream(byteArray);
        }

        private List<string> GetNames(string text)
        {
            var a = DependencyFactory.Resolve<ITextFileProcessor>().ProcessNames(GetMockText(text), text.Length);
            return a;
        } 
    }
}
