using KatmanliMimariBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KatmanliMimari.UI.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textboxdaki değerleri değişkenlere atıyoruz.
            string ıd = textBox1.Text;
            string sifre = textBox2.Text.ToString();
            //LoginBLL den bir nesne türetiyoruz.
            LoginBLL loginbll = new LoginBLL();

            //DAL Katmanında return olarak ture dönerse yeni bir form açılacak
            if (loginbll.Login(ıd, sifre))
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
            }
            //False dönerse hata verecek.
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //form3 den yeni bir nesne türetiyoruz.
            Form3 frm3 = new Form3();
            //Butona tıkladıgımız zaman form3 açılacak.
            frm3.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
