using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Application.Utility
{
    public static class RegexUtil
    {
        public static string lettersnumbersunderscorehyphen = "^[A-Za-z0-9_-]+";
        public static string Uppercaseunderscorenumbers = "^[A-Z0-9_]+";
        public static string CharactersMaximum100 = "^[0-9A-Za-z!@.,;:'\"?-]{1,100}\\z";
    }
}
