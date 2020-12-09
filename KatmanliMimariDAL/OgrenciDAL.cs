    using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimariDAL
{
    public class OgrenciDAL
    {

        private DBConnectionDAL dbConnection;

        //constructor oluşturduk
        public OgrenciDAL()
        {
            //constructorun içinde DBCoonection sınıfından
            dbConnection = new DBConnectionDAL();
        }

        //boolean türünde fonksiyon yazdım bunu kullanici kayıt ederken okul numarası sorgulayıp hata vermesi veya 
        //kaydedilmesi için yazdım eğer okulno veritabanında varsa true dönecek ve hata mesajı çıkaracağım.
        public bool OgrenciEkle(string ad, string soyad , string dogumyili, string bolum, string cinsiyet,string tcno,string ogretmenıd)
        {
            //komut nesnesi türettim.
            OleDbCommand cmd = dbConnection.GetAccessCommand();
            //gelen parametrelerden okulno sorgusu yapıyorum.Eğer daha önce kullanılmışsa kaydetmiyor.
            cmd.CommandText = string.Format("Select * from Ogrenci Where tcno ='{0}'",tcno);
            //Okul no sorguluyor
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //Eğer Sorgu sonucunda veri bulunursa Kayıt yaptırmayıp true döndürüyorum.
                return true;
            }
            else
            {
                //Datareader'i kapatıyorum.
                dr.Close();
                //Eğer okul numarası kayıtlı değilse veritabanına yeni öğrenci ekliyorum.
                string cmdtext = string.Format("INSERT INTO Ogrenci (ad,soyad,dogumyili,bolum,cinsiyet,tcno,ogretmenıd) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", ad, soyad, dogumyili, bolum, cinsiyet, tcno, ogretmenıd);
                cmd.CommandText = cmdtext;
                cmd.ExecuteNonQuery();
                return false;
            }
        }

        //DataTable türünde bir method yazdım.
        public DataTable OgrenciListele()
        {
            // Yeni bir cmd nesnesi türettim ve sorgudan gelen verileri datatable a attım.
            OleDbCommand cmd = dbConnection.GetAccessCommand();
            //SQL sorgusu yazıyorum.
            cmd.CommandText = string.Format("Select * from Ogrenci");
            //Bir datatable nesnesi türettim.
            DataTable dt = new DataTable();
            //Veritabanından gelen verileri datatable'a attım.
            dt.Load(cmd.ExecuteReader());
            //Method çağırıldığında bu dt nesnesini döndürecek
            return dt;
        }

        //Güncelleme için bir fonksiyon yazdım. 
        public void OgrenciGuncelle(string kimlik, string ad,string soyad, string dogumyili, string bolum, string cinsiyet, string tcno, string ogretmenıd)
        {
            //Komut nesnesi itürettim
            OleDbCommand cmd = dbConnection.GetAccessCommand();
            //sql sorgusu yazdım
            string text = string.Format("UPDATE Ogrenci SET ad='{1}', soyad='{2}', dogumyili='{3}', " +
                "bolum='{4}', cinsiyet='{5}', tcno='{6}', ogretmenıd='{7}' WHERE Kimlik = {0}", 
                kimlik,ad, soyad,dogumyili,bolum,cinsiyet,tcno,ogretmenıd);
            cmd.CommandText = text;
            //komutu execute ediyorum.
            cmd.ExecuteNonQuery();
        }

        //Ogrenci Silmek için method yazıyorum.
        public void OgrenciSil(string kimlik)
        {
            //Komut nesnesi itürettim
            OleDbCommand cmd = dbConnection.GetAccessCommand();
            //Silinecek öğrenciyi belirleyen sql kodu yazdım.
            cmd.CommandText = string.Format("Delete From Ogrenci Where Kimlik={0}", kimlik);
            //komutu çalıştırıyorum(execute!)
            cmd.ExecuteNonQuery();
        }

        //datatable türünde Method oluşturuyorum.
        public DataTable NotSorgula(string ogrencitc)
        {
            //komut nesnesi türettim.
            OleDbCommand cmd = dbConnection.GetAccessCommand();
            //Sql sorgusu yazdım 
            cmd.CommandText = string.Format("Select not1,not2,not3 From Notlar where ogrencitc='{0}'", ogrencitc);
            //Yeni Bir datatable nesnesi türettim.
            DataTable dt = new DataTable();
            //Veritabanından gelen bilgileri datatable'a attım.
            dt.Load(cmd.ExecuteReader());
            //Method çağırıldıgında içerisine veri eklenmiş datatable nesnesini döndürecek.
            return dt;
        }
    }
}
