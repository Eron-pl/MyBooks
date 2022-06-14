using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Other
{
    public static class ConnectionString
    {
        public static string Address 
        { 
            get
            {
                string result = "";
                if (File.Exists(Directory.GetCurrentDirectory() + @"\connection-string.txt"))
                {
                    result = File.ReadAllText(Directory.GetCurrentDirectory() + @"\connection-string.txt"); 
                }
                return result;
            }

            set
            {
                string cString = value;
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\connection-string.txt", cString);
            }
        }

        
    }
}
