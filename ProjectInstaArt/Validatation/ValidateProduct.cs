using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectInstaArt.Validatation
{
    public static class ValidateProduct
    {
        public static bool CheckProductCode(string productCode)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                return false;
            }
            string patter = @"^[a-zA-Z0-9]{4,}$";
            Regex regex1 = new Regex(patter);
            if(!regex1.IsMatch(productCode))
            {
                return false;
            }
            if (!Regex.IsMatch(productCode, "[a-zA-Z]"))
            {
                return false;
            }


          


            if (!Regex.IsMatch(productCode, "\\d"))
            {
                return false;
            }

            return true;
        }
       public static bool ValidateProductName(string productName)
        {
            string pattern = @"^[a-zA-ZàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ\s-]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(productName);
        }
       public static bool ValidateCategoryName(string categoryName)
        {
            string pattern = @"^[a-zA-ZàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ\s-]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(categoryName);
        }
      public  static bool CheckName(string name)
        {
            string pattern = @"^[a-zA-ZàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ\s-]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(name);
        }
    }
}
