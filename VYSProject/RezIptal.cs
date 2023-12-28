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
    public partial class RezIptal : Form
    {
        NpgsqlConnection baglanti = new NpgsqlConnection(@"Server = localhost; Port=5432; User Id= postgres; Password= admin;Database=Library Reservation Automation");

        public RezIptal()
        {
            InitializeComponent();
        }

        private void rezIp_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            var cimbom = new NpgsqlCommand("select aktiffkullaniciid from aktiffkullanici", baglanti);
            var reade = cimbom.ExecuteReader();
            string a = "";
            if (reade.Read())
            {
                a = reade["aktiffkullaniciid"].ToString();
            }
            int b = Convert.ToInt32(a);
            
            baglanti.Close();
            baglanti.Open();
            var command = new NpgsqlCommand("select kullaniciadi from kullanici where kullaniciid = @p3", baglanti);
            command.Parameters.AddWithValue("@p3", b);
            var reader = command.ExecuteReader();

            string eskiad = "";
            if(reader.Read()) 
            {
                eskiad = reader["kullaniciadi"].ToString();
            }

            baglanti.Close();
            baglanti.Open();
            
            var com = new NpgsqlCommand("update sandalye set kullanici = 'admin' where kullanici = @eskiad", baglanti);
            com.Parameters.AddWithValue("@eskiad", eskiad);
            com.ExecuteNonQuery();

            MessageBox.Show("Rezervasyonunuz iptal edildi. Yine bekleriz.");

            islemTuru iT = new islemTuru();
            this.Hide();
            iT.Show();
        }
    }
}
