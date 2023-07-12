using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Dal_Factory
    {
        public static Idal get_dal()
        {
            return new Dal_imp();
        }
    }
}
