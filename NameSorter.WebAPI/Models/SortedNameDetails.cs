using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NameSorter.WebAPI.Models
{
    /// <summary>
    /// This class will be return to the requester with the status and output
    /// </summary>
    public class SortedNameDetails
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string SortedNameList { get; set; }
    }
}