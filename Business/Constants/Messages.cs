using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Ürün eklendi";
        public static string CarNotAdded = "Araba ismi minimum 2 karakter olmalı ve günlük fiyat 0 dan büyük olmalı";
        public static string IsRentalReturnDateNull = "Arabayı teslim etmeden kiralayamazsın";
    }
}
