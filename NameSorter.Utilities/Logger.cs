using log4net;
using System;

namespace NameSorter.Utilities
{
    public static class Logger
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogError(string message, Exception ex)
        {
            Log.Error(message, ex);
        }
    }
}
