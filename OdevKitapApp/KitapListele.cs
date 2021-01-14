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
    public partial class KitapListele : Form
    {
        SqlConnection cn = null;
        public KitapListele()
        {
            InitializeComponent();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            using (cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select Kitapad,Yazarad,Yazarsoyad,Sayfasayisi,Kitaptürü from  tblkitap where Kitapad =@Kitapad", cn))
                {
                    SqlParameter[] p = { new SqlParameter("@Kitapad", txtkitapadi.Text.Trim()) };
                    cmd.Parameters.AddRange(p);
                    if (cn != null && cn.State != ConnectionState.Open)
                    {
                        cn.Open();
                    }
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Form1 ktp = (Form1)Application.OpenForms["Form1"];

                        ktp.txtkitapad.Text = dr["Kitapad"].ToString();
                        ktp.txtyazarad.Text = dr["Yazarad"].ToString();
                        ktp.txtyazarsoyad.Text = dr["Yazarsoyad"].ToString();
                        ktp.txtsayfasayisi.Text = dr["Sayfasayisi"].ToString();
                        ktp.txtkitaptürü.Text = dr["Kitaptürü"].ToString();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Öğrenci bulunamadı");
                    }
                    dr.Close();
                }

            }
        }
    }
}
