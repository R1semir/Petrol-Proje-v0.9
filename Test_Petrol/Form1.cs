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

namespace Test_Petrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=r1se\SQLEXPRESS;Initial Catalog=testBenzin;Integrated Security=True");

        void listele()
        {
            // Kurşunsuz95
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_Benzin where PetrolTur='V/Max Kurşunsuz 95'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblKurşunsuz95.Text = dr[3].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                lbl95Litre.Text = dr[4].ToString();
            }
            baglanti.Close();

            //V/Max Diesel
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from tbl_Benzin where PetrolTur='V/Max Diesel'", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblmaxdiesel.Text = dr1[3].ToString();
                progressBar2.Value = int.Parse(dr1[4].ToString());
                lblMaxLitre.Text = dr1[4].ToString();

            }
            baglanti.Close();

            //V/Pro Diesel
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from tbl_Benzin where PetrolTur='V/Pro Diesel'", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblProdiesel.Text = dr2[3].ToString();
                progressBar3.Value = int.Parse(dr2[4].ToString());
                lblProDieselLitre.Text = dr2[4].ToString();
            }
            baglanti.Close();

            //PO/gaz Otogaz
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from tbl_Benzin where PetrolTur='PO/gaz Otogaz'", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblGaz.Text = dr3[3].ToString();
                progressBar4.Value = int.Parse(dr3[4].ToString());
                lblGazLitre.Text = dr3[4].ToString();
            }
            baglanti.Close();

            //kasa
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("select * from tbl_Kasa",baglanti);
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblKasa.Text = dr7[0].ToString();
            }
            baglanti.Close();

            //Alış Fiyat
            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("select * from tbl_Benzin where PetrolTur='V/Max Kurşunsuz 95'",baglanti);
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lbl95alıs.Text = dr8[2].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut9 = new SqlCommand("select * from Tbl_Benzin where PetrolTur='V/Max Diesel'", baglanti);
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                lblmaxdıeselALIS.Text = dr9[2].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut10 = new SqlCommand("select * from TBl_Benzin where PetrolTur='V/Pro Diesel'",baglanti);
            SqlDataReader dr10 = komut10.ExecuteReader();
            while (dr10.Read())
            {
                lblproALIS.Text = dr10[2].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut11 = new SqlCommand("select * from tbl_benzin where PetrolTur='PO/gaz Otogaz'",baglanti);
            SqlDataReader dr11 = komut11.ExecuteReader();
            while (dr11.Read())
            {
                lblGazAlıs.Text = dr11[2].ToString();
            }
            baglanti.Close();

         
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
            btnDepoDoldur.Enabled = false;
            btnBenzinAlıs.Enabled = false;
         

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunz95, litre, tutar;
            kursunz95 = Convert.ToDouble(lblKurşunsuz95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunz95 * litre;
            txtKursunsuz95Fiyat.Text = tutar.ToString();

            double alis95, litrealis, tutaralis;
            alis95 = Convert.ToDouble(lbl95alıs.Text);
            litrealis = Convert.ToDouble(numericUpDown1.Value);
            tutaralis = alis95 * litrealis;
            txtAlıstutar.Text = tutaralis.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double diesel, litre, fiyat;
            diesel = Convert.ToDouble(lblmaxdiesel.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            fiyat = diesel * litre;
            txtVmaxDieselFiyat.Text = fiyat.ToString();

            double alisdiesel, alislitre, tutarfiyat;
            alisdiesel = Convert.ToDouble(lblmaxdıeselALIS.Text);
            alislitre = Convert.ToDouble(numericUpDown2.Value);
            tutarfiyat = alisdiesel * alislitre;
            txtAlıstutar.Text = tutarfiyat.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double prodiesel, litre, tutar;
            prodiesel = Convert.ToDouble(lblProdiesel.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = prodiesel * litre;
            txtProDieselFiyat.Text = tutar.ToString();

            double prodieselalis, alislitre, alistutar;
            prodieselalis = Convert.ToDouble(lblproALIS.Text);
            alislitre =Convert.ToDouble(numericUpDown3.Value);
            alistutar = prodieselalis * alislitre;
            txtAlıstutar.Text = alistutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double otogaz, litre, tutar;
            otogaz = Convert.ToDouble(lblGaz.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = otogaz * litre;
            txtOtogazFiyat.Text = tutar.ToString();

            double otogazalim, alislitre, alistutar;
            otogazalim = Convert.ToDouble(lblGazAlıs.Text);
            alislitre = Convert.ToDouble(numericUpDown4.Value);
            alistutar = otogazalim * alislitre;
            txtAlıstutar.Text = alistutar.ToString();
        }

        private void btnDepoDoldur_Click(object sender, EventArgs e)
        {
            //95
            btnBenzinAlıs.Enabled = true;
            if(numericUpDown1.Value != 0)
            {
               
                baglanti.Open();
                SqlCommand komut4 = new SqlCommand("insert into Tbl_hareket (Plaka,BenzinTürü,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)",baglanti);
                komut4.Parameters.AddWithValue("@p1",txtPlaka.Text);
                komut4.Parameters.AddWithValue("@p2", "V/Max Kurşunsuz 95");
                komut4.Parameters.AddWithValue("@p3",numericUpDown1.Value);
                komut4.Parameters.AddWithValue("@p4",decimal.Parse(txtKursunsuz95Fiyat.Text));
                komut4.ExecuteNonQuery();
                baglanti.Close();
              
                //
                baglanti.Open();
                SqlCommand komut5 = new SqlCommand("update Tbl_kasa set MIKTAR=MIKTAR+@p5",baglanti);
                komut5.Parameters.AddWithValue("@p5",decimal.Parse(txtKursunsuz95Fiyat.Text));
                komut5.ExecuteNonQuery();
                baglanti.Close();

                //
                baglanti.Open();
                SqlCommand komut6 = new SqlCommand("update tbl_Benzin set STOK=STOK-@p6 where PetrolTur='V/Max Kurşunsuz 95'",baglanti);
                komut6.Parameters.AddWithValue("@p6",numericUpDown1.Value);
                komut6.ExecuteNonQuery();
                baglanti.Close();
                listele();
                MessageBox.Show("Satış Başarılı");
            }
            //max
            if (numericUpDown2.Value != 0)
            {

                baglanti.Open();
                SqlCommand komut22 = new SqlCommand("insert into Tbl_hareket (Plaka,BenzinTürü,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", baglanti);
                komut22.Parameters.AddWithValue("@p1", txtPlaka.Text);
                komut22.Parameters.AddWithValue("@p2", "V/Max Diesel");
                komut22.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                komut22.Parameters.AddWithValue("@p4", decimal.Parse(txtVmaxDieselFiyat.Text));
                komut22.ExecuteNonQuery();
                baglanti.Close();

                //
                baglanti.Open();
                SqlCommand komut25 = new SqlCommand("update Tbl_kasa set MIKTAR=MIKTAR+@p5", baglanti);
                komut25.Parameters.AddWithValue("@p5", decimal.Parse(txtVmaxDieselFiyat.Text));
                komut25.ExecuteNonQuery();
                baglanti.Close();

                //
                baglanti.Open();
                SqlCommand komut26 = new SqlCommand("update tbl_Benzin set STOK=STOK-@p6 where PetrolTur='V/Max Diesel'", baglanti);
                komut26.Parameters.AddWithValue("@p6", numericUpDown2.Value);
                komut26.ExecuteNonQuery();
                baglanti.Close();
                listele();
                MessageBox.Show("Satış Başarılı");
            }
            //pro
            if (numericUpDown3.Value != 0)
            {

                baglanti.Open();
                SqlCommand komut32 = new SqlCommand("insert into Tbl_hareket (Plaka,BenzinTürü,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", baglanti);
                komut32.Parameters.AddWithValue("@p1", txtPlaka.Text);
                komut32.Parameters.AddWithValue("@p2", "V/Pro Diesel");
                komut32.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                komut32.Parameters.AddWithValue("@p4", decimal.Parse(txtProDieselFiyat.Text));
                komut32.ExecuteNonQuery();
                baglanti.Close();

                //
                baglanti.Open();
                SqlCommand komut35 = new SqlCommand("update Tbl_kasa set MIKTAR=MIKTAR+@p5", baglanti);
                komut35.Parameters.AddWithValue("@p5", decimal.Parse(txtProDieselFiyat.Text));
                komut35.ExecuteNonQuery();
                baglanti.Close();

                //
                baglanti.Open();
                SqlCommand komut36 = new SqlCommand("update tbl_Benzin set STOK=STOK-@p6 where PetrolTur='V/Pro Diesel'", baglanti);
                komut36.Parameters.AddWithValue("@p6", numericUpDown3.Value);
                komut36.ExecuteNonQuery();
                baglanti.Close();
                listele();
                MessageBox.Show("Satış Başarılı");
            }
            //gaz
            if (numericUpDown4.Value != 0)
            {

                baglanti.Open();
                SqlCommand komut42 = new SqlCommand("insert into Tbl_hareket (Plaka,BenzinTürü,LITRE,FIYAT) values (@p1,@p2,@p3,@p4)", baglanti);
                komut42.Parameters.AddWithValue("@p1", txtPlaka.Text);
                komut42.Parameters.AddWithValue("@p2", "PO/gaz Otogaz");
                komut42.Parameters.AddWithValue("@p3", numericUpDown4.Value);
                komut42.Parameters.AddWithValue("@p4", decimal.Parse(txtOtogazFiyat.Text));
                komut42.ExecuteNonQuery();
                baglanti.Close();

                //
                baglanti.Open();
                SqlCommand komut45 = new SqlCommand("update Tbl_kasa set MIKTAR=MIKTAR+@p5", baglanti);
                komut45.Parameters.AddWithValue("@p5", decimal.Parse(txtOtogazFiyat.Text));
                komut45.ExecuteNonQuery();
                baglanti.Close();

                //
                baglanti.Open();
                SqlCommand komut46 = new SqlCommand("update tbl_Benzin set STOK=STOK-@p6 where PetrolTur='PO/gaz Otogaz'", baglanti);
                komut46.Parameters.AddWithValue("@p6", numericUpDown4.Value);
                komut46.ExecuteNonQuery();
                baglanti.Close();
                listele();
                MessageBox.Show("Satış Başarılı");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            btnDepoDoldur.Enabled = false;
          



            if (Cvmax95C.Checked)
            {
                //depoya benzin alış
                if (progressBar1.Value < 10000)
                {
                    baglanti.Open();
                    SqlCommand komut13 = new SqlCommand("update tbl_benzin set Stok=stok+@p13 where Stok<10000 and PetrolTur='V/Max Kurşunsuz 95'", baglanti);
                    komut13.Parameters.AddWithValue("@p13", numericUpDown1.Value);
                    komut13.ExecuteNonQuery();
                    baglanti.Close();
                    progressBar1.Value += int.Parse(numericUpDown1.Value.ToString());
                    listele();
                    MessageBox.Show("V/Max Kurşunsuz 95 Alış başarılı", "Bilgi", MessageBoxButtons.OK);
                    //kasadan para azaltış

                    baglanti.Open();
                    SqlCommand komut12 = new SqlCommand("update tbl_KASA set MIKTAR=MIKTAR-@p12", baglanti);
                    komut12.Parameters.AddWithValue("@p12", decimal.Parse(txtAlıstutar.Text));
                    komut12.ExecuteNonQuery();
                    baglanti.Close();
                 
                }
            }
            if (CvmaxdieselC.Checked)
            {
                if (progressBar2.Value < 10000)
                {
                    baglanti.Open();
                    SqlCommand komut13 = new SqlCommand("update tbl_benzin set Stok=stok+@p93 where Stok<10000 and PetrolTur='V/Max Diesel'", baglanti);
                    komut13.Parameters.AddWithValue("@p93", numericUpDown2.Value);
                    komut13.ExecuteNonQuery();
                    baglanti.Close();
                    progressBar1.Value += int.Parse(numericUpDown2.Value.ToString());
                    listele();
                    MessageBox.Show("V/Max Diesel Alış başarılı", "Bilgi", MessageBoxButtons.OK);
                    //kasadan para azaltış

                    baglanti.Open();
                    SqlCommand komut12 = new SqlCommand("update tbl_KASA set MIKTAR=MIKTAR-@p92", baglanti);
                    komut12.Parameters.AddWithValue("@p92", decimal.Parse(txtAlıstutar.Text));
                    komut12.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            if (CprodieselC.Checked)
            {
                if (progressBar2.Value < 10000)
                {
                    baglanti.Open();
                    SqlCommand komut03 = new SqlCommand("update tbl_benzin set Stok=stok+@p03 where Stok<10000 and PetrolTur='V/Pro Diesel'", baglanti);
                    komut03.Parameters.AddWithValue("@p03", numericUpDown3.Value);
                    komut03.ExecuteNonQuery();
                    baglanti.Close();
                    progressBar1.Value += int.Parse(numericUpDown3.Value.ToString());
                    listele();
                    MessageBox.Show("V/Pro Diesel Alış başarılı", "Bilgi", MessageBoxButtons.OK);
                    //kasadan para azaltış

                    baglanti.Open();
                    SqlCommand komut02 = new SqlCommand("update tbl_KASA set MIKTAR=MIKTAR-@p02", baglanti);
                    komut02.Parameters.AddWithValue("@p02", decimal.Parse(txtAlıstutar.Text));
                    komut02.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            if (cOtoGaxC.Checked)
            {
                if (progressBar4.Value < 10000)
                {
                    baglanti.Open();
                    SqlCommand komut04 = new SqlCommand("update tbl_benzin set Stok=stok+@p04 where Stok<10000 and PetrolTur='PO/gaz Otogaz'", baglanti);
                    komut04.Parameters.AddWithValue("@p04", numericUpDown4.Value);
                    komut04.ExecuteNonQuery();
                    baglanti.Close();
                    progressBar1.Value += int.Parse(numericUpDown4.Value.ToString());
                    listele();
                    MessageBox.Show("PO/gaz Otogaz Alış başarılı", "Bilgi", MessageBoxButtons.OK);
                    //kasadan para azaltış

                    baglanti.Open();
                    SqlCommand komut05 = new SqlCommand("update tbl_KASA set MIKTAR=MIKTAR-@p05", baglanti);
                    komut05.Parameters.AddWithValue("@p05", decimal.Parse(txtAlıstutar.Text));
                    komut05.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
        }
        private void txtPlaka_TextChanged(object sender, EventArgs e)
        {
            btnDepoDoldur.Enabled = true;
        }
    }
}
