using NameSorter.BusinessContract;
using NameSorter.Utilities;

namespace NameSorter.BusinessImplementation
{
    /// <summary>
    /// Validation rules will resides in this class
    /// </summary>
    public class Validator : IValidator
    {
        /// <summary>
        /// Validate File Type as this application allows only txt files
        /// </summary>
        /// <param name="fileType">file extention Eg:.txt, .doc, .jpg</param>
        /// <returns></returns>
        public string ValidateFileType(string fileType)
        {
            return string.IsNullOrEmpty(fileType) || fileType.ToLower() != ".txt"
                ? NotificationMessages.InValidFileType
                : "";
        }
    }
}
