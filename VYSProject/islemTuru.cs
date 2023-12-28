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
    public partial class islemTuru : Form
    {
        NpgsqlConnection baglanti = new NpgsqlConnection(@"Server = localhost; Port=5432; User Id= postgres; Password= admin;Database=Library Reservation Automation");


        public islemTuru()
        {
            InitializeComponent();
        }

        private void kitAl_Click(object sender, EventArgs e)
        {
            kitapForm kF = new kitapForm();
            kF.ShowDialog();
            this.Hide();
        }

        private void rezAl_Click(object sender, EventArgs e)
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

            var command = new NpgsqlCommand("select kullanici from sandalye where kullanici = @name ", baglanti);
            command.Parameters.AddWithValue("@name", st);

            var readerr = command.ExecuteReader();
            
            if(readerr.Read())
            {
                RezIptal rz = new RezIptal();
                this.Hide();
                rz.ShowDialog();
            }
            else 
            {
                masaRez mF = new masaRez();
                this.Hide();
                mF.ShowDialog();
            }
   
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
