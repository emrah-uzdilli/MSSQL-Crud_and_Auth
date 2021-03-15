using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            sifre.PasswordChar = '*';
            sifreonay.PasswordChar = '*';
        }
        SqlConnection baglanti = new SqlConnection("Data Source=EMRAHZ800\\MSSQLSERVER1;Initial Catalog=enginneribg;Integrated Security=True");

        public object Messagebox { get; private set; }
        public object Else { get; private set; }

        DataTable yenile()
        {

            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from uyeler", baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();

            return tablo;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (sifre.Text == sifreonay.Text)
            {
                baglanti.Open();
                SqlCommand kayit = new SqlCommand("insert into uyeler (kullanici_adi,sifre) values (@p1,@p2)", baglanti);
                kayit.Parameters.AddWithValue("@p1", kullaniciadi.Text);
                kayit.Parameters.AddWithValue("@p2", sifre.Text);
                MessageBox.Show("Kayıt İşlemi Tamamlandı!", "Bilgilendirme Penceresi");
                kayit.ExecuteNonQuery();
                baglanti.Close();

                Form2 yeni = new Form2();
                yeni.Show();//Burada daha önceden belirlediğimiz methoda göre 2.formu göster diyoruz.
                this.Hide();//Burada ise bulunduğumuz form olan 1.formu gizliyoruz.
            }

            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
           
        }
    }
}
