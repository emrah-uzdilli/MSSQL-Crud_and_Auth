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
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form2()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        SqlConnection baglanti = new SqlConnection("Data Source=EMRAHZ800\\MSSQLSERVER1;Initial Catalog=enginneribg;Integrated Security=True");

         public object Messagebox { get; private set; }
        public object Else { get; private set; }

        

       


        private void button1_Click(object sender, EventArgs e)
        {

            string user = textBox1.Text;
            string pass = textBox2.Text;
            con = new SqlConnection("Data Source=EMRAHZ800\\MSSQLSERVER1;Initial Catalog=enginneribg;Integrated Security=True");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM uyeler where kullanici_adi='" + textBox1.Text + "' AND sifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız. ");
                Form1 yeni = new Form1();
                yeni.Show();//Burada daha önceden belirlediğimiz methoda göre 2.formu göster diyoruz.
                this.Hide();//Burada ise bulunduğumuz form olan 1.formu gizliyoruz.
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                textBox1.Clear();
                //Yeni bir giriş için kullanıcı adı bölümünü temizliyoruz.
                textBox2.Clear();
            }
            con.Close();





            // form 2'ye daha sonra ulaşmak için yeni bir method belirliyoruz.
                                     //  if (textBox1.Text == "admin" && textBox2.Text == "12345")
                                     //  {//Kullanıcı adı ve şifremizi belirliyoruz ve doğru olması durumunda yapılması gereken işlemleri yazıyoruz.
                                     //yeni.Show();//Burada daha önceden belirlediğimiz methoda göre 2.formu göster diyoruz.
                                     //this.Hide();//Burada ise bulunduğumuz form olan 1.formu gizliyoruz.
                                     //else
                                     //{//eğer kullanıcı adı ve şifre doğru değil ise yapılacaklar.
                                     //MessageBox.Show("Giriş Başarısız");
                                     //Bir message box ile "giriş başarısız" ifadesini gösteriyoruz.
                                     //textBox1.Clear();
                                     //Yeni bir giriş için kullanıcı adı bölümünü temizliyoruz.
                                     //textBox2.Clear();
                                     //Yeni bir giriş için şifre bölümünü temizliyoruz.
                                     // }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 yeni = new Form3();
            yeni.Show();//Burada daha önceden belirlediğimiz methoda göre 2.formu göster diyoruz.
            this.Hide();//Burada ise bulunduğumuz form olan 1.formu gizliyoruz.
        }
    }
}
