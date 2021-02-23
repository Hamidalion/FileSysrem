using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Lab2_FileStorage
{
    public class Login
    {
        public static bool Auth(string login, string password)
        {
            if (ConfigurationManager.AppSettings["login"] == login && ConfigurationManager.AppSettings["password"] == password)
            {
                bool result = true;
                return result;
            }
            else
            {
                bool result = false;
                return result;
            }
        }
    }
}
