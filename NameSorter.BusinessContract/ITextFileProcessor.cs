using System.Collections.Generic;
using System.IO;

namespace NameSorter.BusinessContract
{
    public interface ITextFileProcessor
    {
        List<string> ProcessNames(Stream fullText, int contentLength);
    }
}
