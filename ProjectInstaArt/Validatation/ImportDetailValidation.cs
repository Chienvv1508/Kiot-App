using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Validatation
{
    public static class ImportDetailValidation 
    {
       public static bool CheckMFGDate( DateTime date)
        {
            if(date > DateTime.Now.Date) return false;
            return true;
        }

      public static bool CheckExpiredDate( DateTime date)
        {
            if (date < DateTime.Now.Date) return false;
            return true;
        }
    }
}
