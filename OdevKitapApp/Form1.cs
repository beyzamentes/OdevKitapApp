using KitapAppKitapBLL;
using KitapAppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdevKitapApp
{
   
    public partial class Form1 : Form
    {  
        SqlConnection cn = null;
        public int kitapid = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                KitapBl ktp = new KitapBl();
                bool sonuc = ktp.KitapEkle(new Kitap(txtkitapad.Text.Trim(), txtyazarad.Text.Trim(), txtyazarsoyad.Text.Trim(), txtsayfasayisi.Text.Trim(), txtkitaptürü.Text.Trim()));
                if (sonuc)
                {
                    MessageBox.Show("İşlem başarılı");
                    temizle();
                }
                else
                {
                    MessageBox.Show("işlem başarısız . tekrar deneyin");
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 1225:
                        MessageBox.Show("Veri tabanı bağlantısı kurulumadı lütfen tekrar deneyin");
                        break;
                    default:
                        break;
                }

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Sistem hatası");

            }
            catch (Exception)
            {
                MessageBox.Show("HATA OLUŞTU");

            }
        }


        private void btnsil_Click(object sender, EventArgs e)
        {
            if (kitapid == 0)
            {
                MessageBox.Show("Önce Kitap Seç !!!");
            }
            else
            {
                DialogResult cvp = MessageBox.Show(txtkitapad.Text + " Adlı Kitabı silmek istediğinizden emin misiniz?", "Kayıt silme onayı", MessageBoxButtons.YesNo);
                if (cvp == DialogResult.Yes)
                {
                    using (cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("Delete from tblkitap where Kitapid=@Kitapid", cn))
                        {
                            SqlParameter[] p = { new SqlParameter("@Kitapid", kitapid) };
                            cmd.Parameters.AddRange(p);
                            if (cn != null && cn.State != ConnectionState.Open)
                            {
                                cn.Open();
                            }
                            int sonuc = cmd.ExecuteNonQuery();
                            if (sonuc > 0)
                            {
                                MessageBox.Show("işlem başarılı");
                                temizle();
                            }
                            else
                            {
                                MessageBox.Show("işlem başarısız");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("KAYIT SİLME İŞLEMİ İPTAL EDİLDİ");
                }

            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            using (cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Update tblkitap set Kitapad=@Kitapad,Yazarad=@Yazarad,Yazarsoyad=@Yazarsoyad,Sayfasayisi=@Sayfasayisi,Kitaptürü=@Kitaptürü where Kitapid=@Kitapid", cn))
                {
                    SqlParameter[] p = { new SqlParameter("@Kitapad", txtkitapad.Text.Trim()), new SqlParameter("@Yazarad", txtyazarad.Text.Trim()),new SqlParameter( "@Yazarsoyad", txtyazarsoyad.Text.Trim()),
                        new SqlParameter("@Sayfasayisi", txtsayfasayisi.Text.Trim()),new SqlParameter("@Kitaptürü", txtkitaptürü.Text.Trim()), new SqlParameter("@Kitapid",kitapid) };
                    cmd.Parameters.AddRange(p);
                    if (cn != null && cn.State != ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    int sonuc = cmd.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        MessageBox.Show("İşlem başarılı");
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("işlem başarısız");
                    }
                }
            }
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            KitapListele ktp = new KitapListele();
            ktp.ShowDialog();
        }

        void temizle()
        {
            txtkitapad.Text = string.Empty;
            txtyazarad.Text = string.Empty;
            txtyazarsoyad.Text = string.Empty;
            txtkitaptürü.Text = string.Empty;
            txtsayfasayisi.Text = string.Empty;
            kitapid = 0;
        }
    }
}
