using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VYSProject
{
    public partial class kitaplarim : Form
    {
        NpgsqlConnection baglanti = new NpgsqlConnection(@"Server = localhost; Port=5432; User Id= postgres; Password= admin;Database=Library Reservation Automation");

        public kitaplarim()
        {
            InitializeComponent();
        }


        private void kitaplarim_Load(object sender, EventArgs e)
        {
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand comm = new NpgsqlCommand("select aktiffkullaniciid from aktiffkullanici", baglanti);
            var reader = comm.ExecuteReader();
            string a = "";
            while (reader.Read())
            {
                a = reader["aktiffkullaniciid"].ToString();
            }
            int b = Convert.ToInt32(a);

            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand lCom = new NpgsqlCommand("select kullaniciadi from kullanici where kullaniciid =@p", baglanti);
            lCom.Parameters.AddWithValue("@p", b);
            var readerr = lCom.ExecuteReader();
            string name = "";
            if (readerr.Read())
            {
                name = readerr["kullaniciadi"].ToString();
            }
            baglanti.Close();
            baglanti.Open();

            NpgsqlCommand com = new NpgsqlCommand("select kitapno, kitapadi, yazaradi, yayinevi from kitaplar where kullanici = @name", baglanti);
            com.Parameters.AddWithValue("@name", name);

            var read = com.ExecuteReader();
            DataTable db_get_data = new DataTable();
            db_get_data.Load(read);

            dataGridView1.DataSource = db_get_data;
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string iade = row.Cells["kitapno"].Value.ToString();
            int iadeid = Convert.ToInt32(iade);

            baglanti.Open();
            NpgsqlCommand com = new NpgsqlCommand("update kitaplar set kullanici = 'admin' where kitapno = @p1", baglanti);
            com.Parameters.AddWithValue("@p1", iadeid);
            com.ExecuteNonQuery();
            kitaplarim_Load(sender, e);
            MessageBox.Show("Iade edildi.");
        }

        private void kitAL_Click(object sender, EventArgs e)
        {
            kitapForm kF = new kitapForm();
            this.Close();
            kF.Show();
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand trun = new NpgsqlCommand("truncate table aktiffkullanici", baglanti);
            Application.Exit();
            trun.ExecuteNonQuery();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
