using DAL;
using KitapAppModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitapAppKitapBLL
{
    public class KitapBl
    {
        public bool KitapEkle(Kitap ktp)
        {
            try
            {
                if (ktp == null)
                {
                    throw new NullReferenceException("Kitap referansı boş geldi");
                }
                SqlParameter[] p = { new SqlParameter("@Kitapad", ktp.Kitapad), new SqlParameter("@Yazarad", ktp.Yazarad), new SqlParameter("@yazarsoyad", ktp.Yazarsoyad), new SqlParameter("@Sayfasayisi", ktp.Sayfasayisi), new SqlParameter("@Kitaptürü", ktp.Kitaptürü) };
                Helper hlp = new Helper();
                return hlp.ExecuteNonQuery("Insert into tblkitap values(@Kitapad,@Yazarad,@Yazarsoyad,@Sayfasayisi,@Kitaptürü)", p) > 0;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
