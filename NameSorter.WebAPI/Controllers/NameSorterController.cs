using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using NameSorter.Utilities;
using System.IO;
using NameSorter.WebAPI.Models;
using NameSorter.BusinessContract;

namespace NameSorter.WebAPI.Controllers
{
    /// <summary>
    /// NameSorter Controller 
    /// </summary>
    public class NameSorterController : ApiController
    {
        /// <summary>
        /// This endpoint will read the uploaded file and process it
        /// </summary>
        /// <returns>SortedNameDetails object will hold the errorMessage or sorted name list</returns>
        [HttpPost]
        public IHttpActionResult GetSortedNames()
        {
            SortedNameDetails nameDetails = new SortedNameDetails();
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

            try
            {
                if (httpPostedFile != null)
                {
                    var fileExt = Path.GetExtension(Path.GetFileName(httpPostedFile.FileName));
                    var status = DependencyFactory.Resolve<IValidator>().ValidateFileType(fileExt);
                    if (string.IsNullOrEmpty(status))
                    {
                        var processedNames =
                            DependencyFactory.Resolve<ITextFileProcessor>().ProcessNames(httpPostedFile.InputStream, httpPostedFile.ContentLength);

                        var sortedNames =
                            DependencyFactory.Resolve<ISortByLasNameFisrtNameAndOtherName>().SortNames(processedNames);

                        nameDetails.SortedNameList = string.Join(Environment.NewLine, sortedNames);
                        nameDetails.ErrorCode = "1";
                    }
                    else
                    {
                        nameDetails.ErrorMessage = status;
                        nameDetails.ErrorCode = "0";
                    }
                }
            }
            catch(Exception ex)
            {
                nameDetails.ErrorMessage = NotificationMessages.SystemError;
                Logger.LogError(ex.Message, ex);
            }

            return Ok(nameDetails);
        }
    }
}
