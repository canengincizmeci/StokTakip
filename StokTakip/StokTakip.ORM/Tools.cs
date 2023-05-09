using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.ORM
{
    public class Tools
    {
        private static SqlConnection baglanti;
        public static SqlConnection Baglanti
        {
            get
            {
                if (baglanti == null)
                    baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
                return baglanti;
            }
        }
        public static DataTable Select(string procName)
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("prc_{0}_Select", procName), Tools.baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public static bool Exec(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                int etk = cmd.ExecuteNonQuery();
                return etk > 0 ? true : false;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed)
                    cmd.Connection.Close();
            }

        }
        public static void ParametreOlustur<T>(SqlCommand cmd, KomutTip kt, T ent)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                string name = pi.Name;
                if ((name.ToLower() == "ıd" || name.ToLower() == "id") && kt == KomutTip.Insert)
                {
                    continue;
                }
                else if ((name.ToLower() != "ıd" || name.ToLower() != "id") && kt == KomutTip.Delete)
                {
                    object value2 = pi.GetValue(ent);
                    cmd.Parameters.AddWithValue("@" + name, value2);
                    break;
                }
                object value = pi.GetValue(ent);
                cmd.Parameters.AddWithValue("@" + name, value);
            }

        }




    }
}
