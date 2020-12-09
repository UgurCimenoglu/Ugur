using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliMimariDAL
{
    public class LoginDAL
    {

        private DBConnectionDAL dbConnection;

        //Constructor oluşturuyoruz.
        public LoginDAL()
        {
            //DBConnectionDAL sınıfından yeni bir nesne türetiyoruz.
            dbConnection = new DBConnectionDAL();
        }

        //Bool türünde bir fonksiyon yazıyoruz bool türünde yazmamızın nedeni formda giriş veya hata döndürmek.
        public bool Login(string ıd,string sifre)
        {
            //yeni bir komut nesnesi türettik.
            OleDbCommand cmd = dbConnection.GetAccessCommand();
            //Sql formdan gelen textbox bilgileri veritabanında aratıyoruz.
            cmd.CommandText = string.Format("Select * from Users Where kullaniciadi ='{0}' and sifre = '{1}'", ıd, sifre);
            //DataReaderdan bir nesne türettik.
            OleDbDataReader dr = cmd.ExecuteReader();

            //Formdan gelen bilgiler ile veritabanı bilgileri eşleşir ise true eşleşmezse false döndüreceğiz.
            if (dr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
