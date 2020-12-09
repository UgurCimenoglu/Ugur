using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KatmanliMimariDAL; // KatmanliMimariDAL sınıfını çağırıyoruz.

namespace KatmanliMimariBLL
{
    public class OgrenciBLL
    {
       private OgrenciDAL ogrencidal;

        //Constructor
        public OgrenciBLL()
        {   //Nesne Türetme
            ogrencidal = new OgrenciDAL();
        }
        //DAL a gönderilecek olan fonksiyon parametreleri
        public bool OgrenciEkle(string ad, string soyad, string dogumyili, string bolum, string cinsiyet, string tcno,string ogretmenıd)
        {
            //Eğer kayıt olursa false dönecek
            if(ogrencidal.OgrenciEkle(ad, soyad, dogumyili, bolum, cinsiyet, tcno, ogretmenıd))
            {
                return false;
            }
            //Eğer okulno daha önceden kullanılmışsa true dönecek.
            else
            {
                return true;
            }
        }
        //datatable türünde method tanımladım.
        public DataTable OgrenciListele()
        {
            //Çağırıldıgı zaman sunum katmanına referans verdiğimiz için methodu return edecek
            return ogrencidal.OgrenciListele();
        }

        //Sunum Katmanından gelen parametreleri DAL katmanına yolluyoruz.
        public void OgrenciGuncelle(string kimlik, string ad, string soyad, string dogumyili, string bolum, string cinsiyet, string tcno, string ogretmenıd)
        {
            ogrencidal.OgrenciGuncelle(kimlik, ad, soyad, dogumyili, bolum, cinsiyet, tcno, ogretmenıd);
        }

        //Sunum Katmanından gelen parametreleri DAL katmanına yolluyoruz.
        public void OgrenciSil(string kimlik)
        {
            ogrencidal.OgrenciSil(kimlik);
        }
        //Sunum Katmanından gelen parametreleri DAL katmanına yolluyoruz.
        public DataTable NotSorgula(string ogrencitc)
        {
            return ogrencidal.NotSorgula(ogrencitc);
        }
    }
}
