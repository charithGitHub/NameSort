using NameSorter.BusinessContract;
using NameSorter.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NameSorter.UnitTest
{
    public static class MockData
    {
        public static List<string> GetNames(string text)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(text);

            return DependencyFactory.Resolve<ITextFileProcessor>().ProcessNames(new MemoryStream(byteArray), text.Length);
        }
    }
}
