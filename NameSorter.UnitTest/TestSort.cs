using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter.Utilities;
using NameSorter.BusinessContract;
using NameSorter.BusinessImplementation;

namespace NameSorter.UnitTest
{
    [TestClass]
    public class TestSort
    {
        public TestSort()
        {
            IApplication app = new Application();
            app.ResolveDependencies();
        }

        [TestMethod]
        public void TestWithBlankText()
        {
            Assert.IsTrue(SortNames("").Count == 0);
        }

        [TestMethod]
        public void TestWithValidText()
        {
            Assert.IsTrue(SortNames("Dan Avantha\r\nSome Charith\r\nSam John\r\nCharith Rodrigo\r\nDonkey zeee").Count > 0);
        }

        [TestMethod]
        public void TestWithInValidText()
        {
            Assert.IsTrue(SortNames("Dan AvanthaSome Charith<nSam John>Charith Rodrigo-Donkey zeee").Count == 1);
        }

        private List<string> SortNames(string text)
        {
            return DependencyFactory.Resolve<ISortByLasNameFisrtNameAndOtherName>().SortNames(MockData.GetNames(text));
        } 
    }
}
