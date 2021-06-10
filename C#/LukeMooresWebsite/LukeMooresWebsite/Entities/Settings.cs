using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LukeMooresWebsite.Entities
{
    public static class Settings
    {
        public static int MaxRequestCharacters()
        {
            return 15;
        }
        public static DateTime StartDate()
        {
            return new DateTime(2017, 06, 01);
        }
        public static double DaysPerYear()
        {
            return 365.25;
        }
        public static int MonthsPerYear()
        {
            return 12;
        }
        public static string APIErrorString()
        {
            return "Something Went Wrong!";
        }
    }
}
