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
using Npgsql;
namespace VYSProject
{
    public partial class kutupSecim : Form
    {
        public kutupSecim()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection(@"Server = localhost; Port=5432; User Id= postgres; Password= admin;Database=Library Reservation Automation");
        
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand com = new NpgsqlCommand("select kutuphane.kutuphaneid, kutuphane.libadi, ilce.ilcead, mahalle.mahallead, sokak.sokakad from kutuphane left join kutuphaneadres on kutuphane.adres = kutuphaneadres.kutupadrid left join ilce on kutuphaneadres.kutupadrid = ilce.ilceid left join mahalle on ilce.mahalleid = mahalle.mahalleid left join sokak on mahalle.mahalleid = sokak.sokakid", baglanti);
            var reader = com.ExecuteReader();
            DataTable db_get_data = new DataTable();
            db_get_data.Load(reader);
            
            dataGridView1.DataSource = db_get_data;
            baglanti.Close();
        }

        private void LibSelected_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand comm = new NpgsqlCommand("select aktiffkullaniciid from aktiffkullanici", baglanti);
            var reader = comm.ExecuteReader();
            string a = "";
            while (reader.Read())
            {
                a = reader["aktiffkullaniciid"].ToString();
            }
            int b = Convert.ToInt32(a);
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string kutuphaneid= row.Cells["kutuphaneid"].Value.ToString();
            int kutid = Convert.ToInt32(kutuphaneid);
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand coms = new NpgsqlCommand("update kullanici set kutuphaneid = @p3 where kullaniciid = @p4", baglanti);
            coms.Parameters.AddWithValue("@p3", kutid);
            coms.Parameters.AddWithValue("@p4", b);
            
            int rowsAffecteds = coms.ExecuteNonQuery();
            islemTuru iT = new islemTuru();
            this.Close();
            iT.ShowDialog();
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand trun = new NpgsqlCommand("truncate table aktiffkullanici", baglanti);
            Application.Exit();
            trun.ExecuteNonQuery();
        }
    }
}
