using NameSorter.BusinessContract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NameSorter.BusinessImplementation
{
    /// <summary>
    /// Process text in the given file
    /// </summary>
    public class TextFileProcessor : ITextFileProcessor
    {
        /// <summary>
        /// Process names in the file
        /// </summary>
        /// <param name="fullText">Content of the file</param>
        /// <param name="contentLength">Length of the content</param>
        /// <returns></returns>
        public List<string> ProcessNames(Stream fullText, int contentLength)
        {
            if (contentLength == 0)
                return new List<string>();

            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(fullText))
            {
                fileData = binaryReader.ReadBytes(contentLength);
            }

            var str = System.Text.Encoding.Default.GetString(fileData);

            return string.IsNullOrEmpty(str) ? new List<string>()  : str.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();

            
        }
    }
}
