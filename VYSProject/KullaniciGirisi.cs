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
    public partial class KullaniciGirisi : Form
    {
        public KullaniciGirisi()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection(@"Server = localhost; Port=5432; User Id= postgres; Password= admin;Database=Library Reservation Automation");
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ad, sifre;
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            var command = new NpgsqlCommand("select * from kullanici", baglanti);

            var reader = command.ExecuteReader();
            bool girdi = false;
            while (reader.Read())
            {
                
                ad = reader["kullaniciadi"].ToString();
                sifre = reader["sifre"].ToString();
                if(txtKull.Text == ad && txtSifre.Text == sifre)
                {
                    kutupSecim frm1 = new kutupSecim();
                    frm1.Show();
                    girdi = true;
                    this.Hide();
                }
                else if(txtKull.Text == ad && txtSifre.Text != sifre)
                {
                    MessageBox.Show("Yanlış Şifre");
                    girdi = true;
                }
                
            }

            baglanti.Close();

            if (!girdi)
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                NpgsqlCommand cmd = new NpgsqlCommand("insert into kullanici (kullaniciadi, sifre) values(@p1, @p2)", baglanti);
                cmd.Parameters.AddWithValue("@p1", txtKull.Text);
                cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
                cmd.ExecuteNonQuery();
                baglanti.Close();
                kutupSecim frm1 = new kutupSecim();
                MessageBox.Show("Kayıt Oluşturuldu.");
                frm1.Show();
                this.Hide();
                baglanti.Close();
            }
            baglanti.Open();
            NpgsqlCommand comi = new NpgsqlCommand("select kullaniciid from kullanici where kullaniciadi = @p1 and sifre = @p2", baglanti);
            comi.Parameters.AddWithValue("@p1", txtKull.Text);
            comi.Parameters.AddWithValue("@p2", txtSifre.Text);
            var read = comi.ExecuteReader();
            int realid = 0;
            if (read.Read())
            {
                string id = read["kullaniciid"].ToString();
                realid = Convert.ToInt32(id);
            }
            baglanti.Close();
            baglanti.Open();
            NpgsqlCommand com = new NpgsqlCommand("insert into aktiffkullanici (aktiffkullaniciid) values(@p3)", baglanti);
            com.Parameters.AddWithValue("@p3", realid);
            com.ExecuteNonQuery();
            
        }
    }
}
