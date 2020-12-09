using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb; //Access Veritabanı için gerekli kütüphane
using System.Data;

namespace KatmanliMimariDAL
{
    class DBConnectionDAL
    {
        //Sadece Okunabilir bir string değişken tanımladık.
        private readonly string _connectionString;

        //Constructor Oluşturduk.
        public DBConnectionDAL()
        {
            //String değişkene access veritabanı bağlantı adresini verdik.
            _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\ugurc\\Desktop\\KatmanliMimari.accdb";
        }

        //Bağlantıyı return eden bir method yazdık.
        private OleDbConnection GetAccessConnection()
        {   
            //Yeni Bir AccesDB connection nesnesi türettik
            OleDbConnection conn = new OleDbConnection(_connectionString);

            //Veritabanını Güncellemek için Fonksiyon her çağırıldığında kapatıp açıyoruz. 
            if(conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            else
            {
                conn.Open();
            }
            // Methodu çağırdığımız zaman bize bağlantıyı döndürecek.
            return conn;
        }

        //Komutlar için method yazdık.
        public OleDbCommand GetAccessCommand()
        {
            //Komut için bir nesne türettik.
            OleDbCommand cmd = new OleDbCommand();
            //Komut nesnesini veritabanı ile ilişkilendiriyoruz.
            cmd.Connection = GetAccessConnection();
            //Method çağırıldıgında geriye döndürülecek.
            return cmd;
        }
    }
}
