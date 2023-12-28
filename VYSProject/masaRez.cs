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

namespace VYSProject
{
    public partial class masaRez : Form
    {
        public masaRez()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection(@"Server = localhost; Port=5432; User Id= postgres; Password= admin;Database=Library Reservation Automation");

        private void masaRez_Load(object sender, EventArgs e)
        {
            baglanti.Close();
            baglanti.Open();
            var cimbom = new NpgsqlCommand("select aktiffkullaniciid from aktiffkullanici", baglanti);
            var reade = cimbom.ExecuteReader();
            string a = "";
            if(reade.Read())
            {
                a = reade["aktiffkullaniciid"].ToString();
            }
            int b = Convert.ToInt32(a);
            reade.Close();
            
            var com = new NpgsqlCommand("select kutuphaneid from kullanici where kullaniciid = @h1", baglanti);
            com.Parameters.AddWithValue("@h1", b);
            
            var reader = com.ExecuteReader();
            string kutid = "";
            while(reader.Read())
            {
                kutid = reader["kutuphaneid"].ToString();
            }

            int kunnateko = Convert.ToInt32(kutid);

            baglanti.Close();
            baglanti.Open();
            
            var comi = new NpgsqlCommand("select sandalyeid, sandalyead, masaadi from sandalye inner join masa on sandalye.masaid = masa.masaid where masa.kutuphaneid = @p6 and sandalye.kullanici = 'admin'", baglanti);
            comi.Parameters.AddWithValue("@p6", kunnateko);
            
            DataTable db = new DataTable();
            var read = comi.ExecuteReader();
            db.Load(read);
            dataGridView1.DataSource = db;

            read.Close();

            baglanti.Close() ;
            baglanti.Open();
            NpgsqlCommand masaToplam = new NpgsqlCommand("select sandalye_sayi(@kutid)", baglanti);
            masaToplam.Parameters.AddWithValue("@kutid", kunnateko);

            var readMasa = masaToplam.ExecuteReader();

            string masaToplamS = "";
            if(readMasa.Read())
            {
                masaToplamS = readMasa[0].ToString();
            }

            topMasa.Text = masaToplamS;
            baglanti.Close();
            
        }


        private void sAnal_Click(object sender, EventArgs e)
        {

            baglanti.Close();
            baglanti.Open();

            var cimbom = new NpgsqlCommand("select aktiffkullaniciid from aktiffkullanici", baglanti);
            var reade = cimbom.ExecuteReader();
            string a = "";
            if (reade.Read())
            {
                a = reade["aktiffkullaniciid"].ToString();
            }
            int b = Convert.ToInt32(a);
            reade.Close();

            baglanti.Close();
            baglanti.Open();

            var com = new NpgsqlCommand("select kullaniciadi from kullanici where kullaniciid = @h1", baglanti);
            com.Parameters.AddWithValue("@h1", b);

            var readeer = com.ExecuteReader();
            string st = "";
            if (readeer.Read())
            {
                st = readeer["kullaniciadi"].ToString();
            }
            readeer.Close();
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int sanid = Convert.ToInt32(row.Cells["sandalyeid"].Value.ToString());

            baglanti.Close();
            baglanti.Open();
            var come = new NpgsqlCommand("update sandalye set kullanici = @p3 where sandalyeid = @k", baglanti);
            come.Parameters.AddWithValue("@k", sanid);
            come.Parameters.AddWithValue("@p3", st);
            come.ExecuteNonQuery();

            MessageBox.Show("Rezervasyonunuz Oluşturuldu.");
            islemTuru iT = new islemTuru();
            this.Close();
            iT.Show();
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            
        }

        private void cikis_Click_1(object sender, EventArgs e)
        {
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand trun = new NpgsqlCommand("truncate table aktiffkullanici", baglanti);
            Application.Exit();
            trun.ExecuteNonQuery();
        }
    }
}
