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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=EMRAHZ800\\MSSQLSERVER1;Initial Catalog=enginneribg;Integrated Security=True");

        public object Messagebox { get; private set; }
        public object Else { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = yenile();
        }

        DataTable yenile(){
        
        baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from ogrenciler",baglanti);
            DataTable tablo = new DataTable();
            adtr.Fill(tablo);
            baglanti.Close();

            return tablo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kayit = new SqlCommand("insert into ogrenciler (okul_no,ad,soyad,yas) values (@p1,@p2,@p3,@p4)", baglanti);
            kayit.Parameters.AddWithValue("@p1", textBox1.Text);
            kayit.Parameters.AddWithValue("@p2", textBox2.Text);
            kayit.Parameters.AddWithValue("@p3", textBox3.Text);
            kayit.Parameters.AddWithValue("@p4", textBox4.Text);
            MessageBox.Show("Kayıt İşlemi Tamamlandı!", "Bilgilendirme Penceresi");
            kayit.ExecuteNonQuery();
            baglanti.Close();
             dataGridView1.DataSource = yenile();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
             
            


            if (MessageBox.Show("Silme işlemi onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand kayitsil = new SqlCommand("Delete from ogrenciler where okul_no=@p1", baglanti);
                kayitsil.Parameters.AddWithValue("@p1", textBox1.Text);
                kayitsil.ExecuteNonQuery();
                baglanti.Close();
                dataGridView1.DataSource = yenile();
            }
            else{
                MessageBox.Show("Kayıt işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
        
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string okul_no = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            String name = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            String surname = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            String age = dataGridView1.Rows[secilen].Cells[3].Value.ToString();


            textBox1.Text = okul_no;
            textBox2.Text = name;
            textBox3.Text = surname;
            textBox4.Text = age;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand update = new SqlCommand("update ogrenciler set okul_no=@p1,ad=@p2,soyad=@p3,yas=@p4 where okul_no=@p1", baglanti);

            update.Parameters.AddWithValue("@p1", textBox1.Text);
            update.Parameters.AddWithValue("@p2", textBox2.Text);
            update.Parameters.AddWithValue("@p3", textBox3.Text);
            update.Parameters.AddWithValue("@p4", textBox4.Text);
            MessageBox.Show("Güncelleme İşlemi Tamamlandı!", "Bilgilendirme Penceresi",MessageBoxButtons.OK ,MessageBoxIcon.Information);
            update.ExecuteNonQuery();
            baglanti.Close();
            dataGridView1.DataSource = yenile();


        }
    }
}
