using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Helper
    {
        SqlConnection cn = null;
        public int ExecuteNonQuery(string cmdtext, SqlParameter[] pr = null)
        {
            try
            {
                using (cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdtext, cn))
                    {
                        if (pr != null)
                        {
                            cmd.Parameters.AddRange(pr);
                        }
                        OpenConnection();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        void OpenConnection()
        {
            if (cn != null && cn.State != ConnectionState.Open)
            {
                cn.Open();
            }
        }
    }
}
