using NameSorter.BusinessContract;
using System.Collections.Generic;
using System.Linq;
using NameSorter.Model;

namespace NameSorter.BusinessImplementation
{
    /// <summary>
    /// Sort By LasName, FisrtName and OtherName
    /// </summary>
    public class SortByLasNameFisrtNameAndOtherName : ISortByLasNameFisrtNameAndOtherName
    {
        /// <summary>
        /// Method will sory list of names first from Last name and then first name and other name
        /// </summary>
        /// <param name="names">string list of names</param>
        /// <param name="asc">caller can change the sort ascending to descending by setting this false default is true</param>
        /// <returns></returns>
        public List<string> SortNames(List<string> names, bool asc = true)
        {
            var query = from line in names
                        let customerRecord = line.Split(' ')
                        select new PersonName()
                        {
                            Firstname = customerRecord.Length > 1 ? customerRecord[0] : "",
                            Othername = customerRecord.Length > 2 ? customerRecord[1] : "",
                            Lastname = customerRecord.Length == 2 ? customerRecord[1] : customerRecord.Length > 2 ? customerRecord[customerRecord.Length - 1] : "",

                        };


            return query.OrderBy(a => a.Lastname).ThenBy(a => a.Firstname).Select(a => a.Firstname + (string.IsNullOrEmpty(a.Othername)? "" : " " + a.Othername) + " " + a.Lastname).ToList();
        }
    }
}
