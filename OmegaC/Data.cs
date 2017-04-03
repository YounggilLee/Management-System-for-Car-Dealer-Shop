using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace OmegaC
{
    public class Data
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["OmegaUsersConnectionString"].ConnectionString;
        }

        public static string GetConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings["OmegaWindConnectionString"].ConnectionString;
        }
    }
}
