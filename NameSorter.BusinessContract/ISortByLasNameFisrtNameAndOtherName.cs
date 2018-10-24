using System.Collections.Generic;

namespace NameSorter.BusinessContract
{
    public interface ISortByLasNameFisrtNameAndOtherName
    {
        List<string> SortNames(List<string> names, bool asc = true);

    }
}
