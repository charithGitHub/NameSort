using NameSorter.BusinessContract;
using NameSorter.Utilities;


namespace NameSorter.BusinessImplementation {
    /// <summary>
    /// This class is to handle application level requirements such as resolving dependencies
    /// </summary>
    public class Application : IApplication {

        /// <summary>
        /// Resolving dependencies
        /// </summary>
        public void ResolveDependencies() {
            DependencyFactory.AddItemtoContainer<IApplication, Application>();
            DependencyFactory.AddItemtoContainer<IValidator, Validator>();
            DependencyFactory.AddItemtoContainer<ISortByLasNameFisrtNameAndOtherName, SortByLasNameFisrtNameAndOtherName>();
            DependencyFactory.AddItemtoContainer<ITextFileProcessor, TextFileProcessor>();
            
        }
    }
}
