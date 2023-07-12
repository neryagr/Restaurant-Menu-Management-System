using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [AttributeUsage(AttributeTargets.Class)]
   public class pathAttribute : Attribute
    {
        public string key;
        public string name;
        public string path { get; set; }
        public pathAttribute(string p,string n,string k)
        {
            path = @"../../../DAL/xml/"+ p;
            name = n;
            key = k;
        }
    }
    public enum DISH_SIZE
    {
        small = 0,
        medium = 1,
        large = 2
    }
    public enum kosher_level
    {
        shrimps,
        cuffer,
        cosher,
        badatz,
        glat
    }
   public enum choise
    {
        hour,
        DayOfMonth,
        Month,
        year
    };
}
