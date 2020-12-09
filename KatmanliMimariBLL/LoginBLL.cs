using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KatmanliMimariDAL; //KatmanliMimariDAL katmanını referans verdik.

namespace KatmanliMimariBLL
{
    public class LoginBLL
    {
        private LoginDAL logindal;

        //constructor oluşturduk.
        public LoginBLL()
        {
            //LoginDAL classından yeni bir nesne türettik.
            logindal = new LoginDAL();
        }

        //bool türünde bir fonksiyon yazdık true ya da false dönecek.
        public bool Login(string ıd, string sifre)
        {
            if (logindal.Login(ıd, sifre))
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
