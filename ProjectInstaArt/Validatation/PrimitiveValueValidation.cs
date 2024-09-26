using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectInstaArt
{
    public static class PrimitiveValueValidation
    {
        internal static bool CheckAddress(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            if (name.Length < 2 || name.Length > 100)
            {
                return false;
            }

            Regex regex = new Regex("^[a-zA-Z0-9][a-zA-Z\\s0-9]+$");
            if (!regex.IsMatch(name))
            {
                return false;
            }

            return true;
        }

        internal static bool CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            if (name.Length < 2 || name.Length > 50)
            {
                return false;
            }

            Regex regex = new Regex(@"^[a-zA-ZàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ][a-zA-ZàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ\s]+$");
            if (!regex.IsMatch(name))
            {
                return false;
            }
           

            return true;
        }

        internal static bool CheckPassword(string password)
        {
            
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

           
            if (password.Length < 8)
            {
                return false;
            }

           
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                return false;
            }

          
            if (!Regex.IsMatch(password, "[a-z]"))
            {
                return false;
            }

           
            if (!Regex.IsMatch(password, "\\d"))
            {
                return false;
            }

           
            if (!Regex.IsMatch(password, "[^a-zA-Z\\d]"))
            {
                return false;
            }

            return true;
        }

        internal static bool CheckPhone(string phoneNumber)
        {

            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }


            string digitsOnly = Regex.Replace(phoneNumber, @"[\s\-\(\)]", "");


            if (digitsOnly.Length != 10)
            {
                return false;
            }


            Regex regex = new Regex(@"^(03|07|08|09|02)\d+$");
            if (!regex.IsMatch(digitsOnly))
            {
                return false;
            }

            return true;
        }

        public static bool CheckText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            if (text.Length < 2 )
            {
                return false;
            }

            Regex regex = new Regex(@"^[a-zA-ZàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ0-9][a-zA-ZàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ0-9\s]+$");
            if (!regex.IsMatch(text))
            {
                return false;
            }


            return true;
        }
    }
}
