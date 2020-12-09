using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace KatmanliMimariDAL
{
    public class OgretmenDAL
    {
        private DBConnectionDAL dbConnection;

        //constructor oluşturduk
        public OgretmenDAL()
        {
            //constructorun içinde DBCoonection sınıfından
            dbConnection = new DBConnectionDAL();
        }

        //boolean türünde fonksiyon yazdım bunu ögretmen kayıt ederken  tcno sorgulayıp hata vermesi veya 
        //kaydedilmesi için yazdım eğer tcno veritabanında varsa true dönecek ve hata mesajı çıkaracağım.
        public bool OgretmenEkle(string ad, string soyad, string brans, string cinsiyet, string telefon,string tcno)
        {
            //komut nesnesi türettim.
            OleDbCommand cmd = dbConnection.GetAccessCommand();
            //gelen parametrelerden okulno sorgusu yapıyorum.Eğer daha önce kullanılmışsa kaydetmiyor.
            cmd.CommandText = string.Format("Select * from Ogretmen Where tcno ='{0}'", tcno);
            //Okul no sorguluyor
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return true;
            }
            else
            {
                //Datareader'i kapatıyorum.
                dr.Close();
                //Eğer tcno kayıtlı değilse veritabanına yeni öğretmen ekliyorum.
                string cmdtext = string.Format("INSERT INTO Ogretmen (Ad,Soyad,Brans,Cinsiyet,Telefon,TCno) values('{0}','{1}','{2}','{3}','{4}','{5}')", ad, soyad, brans, cinsiyet, telefon, tcno);
                cmd.CommandText = cmdtext;
                cmd.ExecuteNonQuery();
                return false;
            }
        }

        //Öğretmenleri listelemek için Fonksiyon
        public DataTable OgretmenListele()
        {
            //yeni bir komut nesnesi
            OleDbCommand cmd = dbConnection.GetAccessCommand();
            //talodaki bütün öğretmenleri listele
            cmd.CommandText = string.Format("Select * From Ogretmen");
            //yeni bir datatable nesnesi
            DataTable dt = new DataTable();
            //veritabanından gelenleri datatable a ekleme
            dt.Load(cmd.ExecuteReader());
            //fonksiyon çağırıldıgında datatable döndürecek.
            return dt;
        }

    }
}
