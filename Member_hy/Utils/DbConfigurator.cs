using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Member_hy.Utils
{
    public class DbConfigurator
    {
        public static string defConnection;
        public static string emrConnection;
        public static void SetConnection(string connection)
        {
            defConnection = connection;
        }

    }
}
