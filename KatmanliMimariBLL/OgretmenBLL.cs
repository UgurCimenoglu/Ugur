using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KatmanliMimariDAL;

namespace KatmanliMimariBLL
{
    public class OgretmenBLL
    {
        private OgretmenDAL ogretmendal;

        //Constructor
        public OgretmenBLL()
        {   //Nesne Türetme
            ogretmendal = new OgretmenDAL();
        }
        //DAL a gönderilecek olan fonksiyon parametreleri
        public bool OgretmenEkle(string ad, string soyad, string brans, string cinsiyet, string telefon, string tcno)
        {
            //Eğer kayıt olursa false dönecek
            if (ogretmendal.OgretmenEkle(ad, soyad, brans, cinsiyet, telefon, tcno))
            {
                return false;
            }
            //Eğer tcno daha önceden kullanılmışsa true dönecek.
            else
            {
                return true;
            }
        }

        //Veritabanındaki öğretenleri listelemek için bll fonksiyonu
        public DataTable OgretmenListele()
        {
            return ogretmendal.OgretmenListele();
        }
    }
}
