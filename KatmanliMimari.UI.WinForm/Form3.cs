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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //İnput değerini değişkene atıyorum.
            string ogrencitc = maskedTextBox4.Text.ToString();
            //OgrenciBLL katmanından yeni bir nesne türetiyoruz.
            OgrenciBLL ogrencibll = new OgrenciBLL();
            try
            {
                //Fonksiyonu çaalıştırmayı deniyorum.Çalışırsa Datagridview de güncellenecek.
              ogrencibll.NotSorgula(ogrencitc);
                dataGridView1.DataSource = ogrencibll.NotSorgula(ogrencitc);
            }
            catch (Exception)
            {
                //Çalışmazsa da datagridview güncellenecek ama hata mesajı fırlatacak.
                dataGridView1.DataSource = ogrencibll.NotSorgula(ogrencitc);
                MessageBox.Show("Böyle bir Öğrenci Kayıtlı Değil veya Not Girişi Yapılmamıştır.");
            }
        }
    }
}
