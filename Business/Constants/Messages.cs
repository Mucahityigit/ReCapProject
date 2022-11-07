﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedSuccessMessage = "Ekleme işlemi başarılı";
        public static string UpdatedSuccessMessage = "Güncelleme işlemi başarılı";
        public static string DeletedSuccessMessage = "Silme işlemi başarılı";
        public static string AddedErrorMessage = "Ekleme işlemi başarısız";
        public static string UpdatedErrorMessage = "Güncelleme işlemi başarısız";
        public static string DeletedErrorMessage = "Silme işlemi başarısız";
        public static string ErrorDailyPriceMessage = "Günlük Kiralama Bedeli O TL den fazla olmalıdır";
        public static string SuccessGetAllMessage = "Veri Listeleme Başarılı";
        public static string ErrorGetAllMessage = "Veri Listeleme Başarısız";
        public static string SuccessGetByIdMessage = "Aranılan Araç Bulundu";
        public static string ErrorGetByIdMessage = "Aranılan Araç Bulunamadı";
        public static string SuccessGetCarsByBrandIdMessage = "Aranılan Markadaki Araçlar Listelendi";
        public static string ErrorGetCarsByBrandIdMessage = "Aranılan Markada Araç Bulunamadı";
        public static string SuccessGetCarsByColorIdMessage = "Aranılan Renkteki Araçlar Listelendi";
        public static string ErrorGetCarsByColorIdMessage = "Aranılan Renkte Araç Bulunamadı";
        public static string SuccessGetCarDetailsMessage = "Araç bilgileri listelendi";
    }
}