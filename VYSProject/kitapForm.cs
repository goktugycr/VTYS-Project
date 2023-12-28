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
    public partial class kitapForm : Form
    {
        public kitapForm()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(@"Server = localhost; Port=5432; User Id= postgres; Password= admin;Database=Library Reservation Automation");

        private void kitapForm_Load(object sender, EventArgs e)
        {
            string search_ = search.Text;

            if (search_ == "")
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
                var Com = new NpgsqlCommand("select kutuphaneid, kullaniciadi from kullanici where kullaniciid = @b", baglanti);
                Com.Parameters.AddWithValue("@b", b);
                var reader2 = Com.ExecuteReader();

                string kut = "";
                if (reader2.Read())
                {
                    kut = reader2["kutuphaneid"].ToString();
                }
                int kutid = Convert.ToInt32(kut);
                baglanti.Close();
                baglanti.Open();
                var command = new NpgsqlCommand("select kitapno, kitapadi, yazaradi, yayinevi from kitaplar left join raflar on kitaplar.rafid = raflar.rafid right join kutuphane on raflar.kutupid = kutuphane.kutuphaneid where kutuphane.kutuphaneid = @kutid and kitaplar.kullanici = 'admin'", baglanti);
                command.Parameters.AddWithValue("@kutid", kutid);
                DataTable dt = new DataTable();
                var reader1 = command.ExecuteReader();
                dt.Load(reader1);

                dataGridView1.DataSource = dt;

                baglanti.Close();
                baglanti.Open();
                NpgsqlCommand topKitCom = new NpgsqlCommand("select toplam_kitap_sayi(@kutid)", baglanti);
                topKitCom.Parameters.AddWithValue("@kutid", Convert.ToInt32(kut));
                var readd = topKitCom.ExecuteReader();

                string topKitSayi = "";
                if (readd.Read())
                {
                    topKitSayi = readd[0].ToString();
                }
                tumKit.Text = topKitSayi;
                baglanti.Close();
            }
            else
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
                var Com = new NpgsqlCommand("select kutuphaneid, kullaniciadi from kullanici where kullaniciid = @b", baglanti);
                Com.Parameters.AddWithValue("@b", b);
                var reader2 = Com.ExecuteReader();

                string kut = "";
                if (reader2.Read())
                {
                    kut = reader2["kutuphaneid"].ToString();
                }
                int kutid = Convert.ToInt32(kut);
                baglanti.Close();
                baglanti.Open();
                var command = new NpgsqlCommand("select kitapno, kitapadi, yazaradi, yayinevi from kitaplar left join raflar on kitaplar.rafid = raflar.rafid right join kutuphane on raflar.kutupid = kutuphane.kutuphaneid where kutuphane.kutuphaneid = @kutid and kitaplar.kullanici = 'admin' and kitaplar.kitapadi LIKE @kitAd", baglanti);
                command.Parameters.AddWithValue("@kutid", kutid);
                command.Parameters.AddWithValue("@kitAd", search_ + "%");
                DataTable dt = new DataTable();
                var reader1 = command.ExecuteReader();
                dt.Load(reader1);

                dataGridView1.DataSource = dt;

                baglanti.Close();
                baglanti.Open();
                NpgsqlCommand topKitCom = new NpgsqlCommand("select toplam_kitap_sayi(@kutid)", baglanti);
                topKitCom.Parameters.AddWithValue("@kutid", Convert.ToInt32(kut));
                var readd = topKitCom.ExecuteReader();

                string topKitSayi = "";
                if (readd.Read())
                {
                    topKitSayi = readd[0].ToString();
                }
                tumKit.Text = topKitSayi;
                baglanti.Close();
            }
        }

        private void kitAl_Click(object sender, EventArgs e)
        {
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand comm = new NpgsqlCommand("select aktiffkullaniciid from aktiffkullanici", baglanti);
            var reader3 = comm.ExecuteReader();
            string a = "";
            while (reader3.Read())
            {
                a = reader3["aktiffkullaniciid"].ToString();
            }
            int b = Convert.ToInt32(a);

            DataGridViewRow row =dataGridView1.SelectedRows[0];
            int kitapno = Convert.ToInt32(row.Cells["kitapno"].Value.ToString());

            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand lCom = new NpgsqlCommand("select kullaniciadi from kullanici where kullaniciid =@p", baglanti);
            lCom.Parameters.AddWithValue("@p", b);
            var reader = lCom.ExecuteReader();
            string name = "";
            if(reader.Read()) 
            {
                name = reader["kullaniciadi"].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand newCom = new NpgsqlCommand("update kitaplar set kullanici = @p1 where kitapno = @p4", baglanti);
            newCom.Parameters.AddWithValue("@p4", kitapno);
            newCom.Parameters.AddWithValue("@p1", name);
            newCom.ExecuteNonQuery();
            MessageBox.Show("Kitap Alındı.");
            kitapForm_Load(sender, e);
        }

        private void myKit_Click(object sender, EventArgs e)
        {
            kitaplarim kp = new kitaplarim();
            this.Close();
            kp.Show();
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand trun = new NpgsqlCommand("truncate table aktiffkullanici", baglanti);
            Application.Exit();
            trun.ExecuteNonQuery();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            kitapForm_Load(sender, EventArgs.Empty);
        }

    }
}
