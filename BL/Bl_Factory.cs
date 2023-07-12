using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public static class Bl_Factory
    {
      static IBL bl = null;
      public static IBL get_ibl()
      {
          if(bl==null)
              bl=new Bl_imp();
          return bl;
      }
    }
}
