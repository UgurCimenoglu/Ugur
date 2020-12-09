using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KatmanliMimariBLL;

namespace KatmanliMimari.UI.WinForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textboxdaki değerleri değişkenlere atadım.
            string ad = textBox1.Text;
            string soyad = textBox2.Text; 
            string dogumyili = dateTimePicker1.Value.ToShortDateString();
            string bolum = comboBox1.SelectedItem.ToString();
            string cinsiyet = comboBox2.SelectedItem.ToString();
            string tcno = maskedTextBox3.Text.ToString();
            string ogretmenıd = textBox3.Text;
            //OgrenciBLL katmanından yeni bir nesne türetiyoruz.
            OgrenciBLL ogrencikayitbll = new OgrenciBLL();

            //eğer Veritabanına öğrenci kaydolursa Kayıt başarılı mesajı yazacak.
            if (ogrencikayitbll.OgrenciEkle(ad, soyad, dogumyili, bolum, cinsiyet, tcno, ogretmenıd))
            {
                
                MessageBox.Show("Kayıt Basarılı");
            }
            //Kayıt olmazsa Hata Mesajı Yazacak.
            else
            {
                MessageBox.Show("Böyle Bir TC Kimlik Numarası Kullanılmaktadır.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //değerleri değişkenlere atadım.
            string ad = textBox5.Text.ToString();
            string soyad = textBox4.Text.ToString();
            string brans = comboBox4.SelectedItem.ToString();
            string cinsiyet = comboBox3.SelectedItem.ToString();
            string telefon = maskedTextBox1.Text.ToString();
            string tcno = maskedTextBox2.Text.ToString();

            //OgrenciBLL katmanından yeni bir nesne türetiyoruz.
            OgretmenBLL ogretmenkayit = new OgretmenBLL();
            //eğer Veritabanına öğrenci kaydolursa Kayıt başarılı mesajı yazacak.
            if (ogretmenkayit.OgretmenEkle(ad, soyad, brans, cinsiyet, telefon, tcno))
            {
                //eğer kayıt başarılı ise olumlu mesaj verecek ve datagridview güncellenecek
                MessageBox.Show("Kayıt Basarılı");
                dataGridView2.DataSource = ogretmenkayit.OgretmenListele();
                dataGridView1.DataSource = ogretmenkayit.OgretmenListele();
            }
            //Kayıt olmazsa Hata Mesajı Yazacak.
            else
            {
                MessageBox.Show("Böyle Bir TC Kimlik Numarası Kullanılmaktadır.");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //combobox varsayılan değerleri 0. index yaptım.
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            //form yüklendiği an datagridviewlerde veriler yüklenecek.
            OgretmenBLL ogretmenbll = new OgretmenBLL();
            dataGridView1.DataSource = ogretmenbll.OgretmenListele();
            dataGridView2.DataSource = ogretmenbll.OgretmenListele();


            OgrenciBLL ogrencibll = new OgrenciBLL();
            dataGridView3.DataSource = ogrencibll.OgrenciListele();





        }


        //DatagridView'de bir satıra tıklayınca o satırdaki bilgileri gerekli inputlara yerleştiriyorum.
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.CurrentRow.Selected = true;
            textBox9.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            textBox6.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox7.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            comboBox5.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            comboBox6.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
            maskedTextBox4.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //İnput Değerlerini değişkenlere aldım.
            string kimlikno = textBox9.Text.ToString();
            string ad = textBox6.Text.ToString();
            string soyad = textBox7.Text.ToString();
            string dogumyili = dateTimePicker2.Value.ToShortDateString();
            string bolum = comboBox5.SelectedItem.ToString();
            string cinsiyet = comboBox6.SelectedItem.ToString();
            string tcno = maskedTextBox4.Text.ToString();
            string ogretmenid = textBox8.Text.ToString();
            //OgrenciBllden yeni bir nesne türettim.
            OgrenciBLL ogrenciGuncelle = new OgrenciBLL();
            try
            {//Hata veya Onay mesajı için Try Catch yapısını kullandım. İnputlardan aldıgımız verileri yolluyoruz.
                ogrenciGuncelle.OgrenciGuncelle(kimlikno, ad, soyad, dogumyili, bolum, cinsiyet, tcno, ogretmenid);
                MessageBox.Show("Güncelleme Başarılı!");
                //Güncelleme başarılı olursa dataGridView de güncellenecek.
                OgrenciBLL ogrencibll = new OgrenciBLL();
                dataGridView3.DataSource = ogrencibll.OgrenciListele();

            }
            catch (Exception)
            {
                //Güncelleme olmazsa hata mesajı fırlatacak.
                MessageBox.Show("Hata Güncelleme Yapılamadı!");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //İnputdaki değeri değişkene atıyorum.
            string kimlik = textBox10.Text.ToString();
            //OgrenciBLL katmanından yeni bir nesne türetiyoruz.
            OgrenciBLL ogrencibll = new OgrenciBLL();

            //Hata yönetimi için try-catch yapısını kullandım.
            try
            {   
                //Eğer fonksiyon çalışır ve veritabanı işlemleri gerçekleştirmeyi deniyoruz.
                ogrencibll.OgrenciSil(kimlik);
                MessageBox.Show("Öğrenci Silindi!");
                //DatagridView güncelletiyorum.
                dataGridView3.DataSource = ogrencibll.OgrenciListele();
            }
            catch (Exception)
            {
                //Hata Yakalarsa mbox ile hata mesajı fırlatıyorum.
                MessageBox.Show("Hata! Öğrenci Silinemedi.");
                
            }
        }
    }
}
