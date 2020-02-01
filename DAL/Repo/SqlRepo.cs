using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class SqlRepo
    {
        private string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        private static readonly Lazy<SqlRepo> lazy = new Lazy<SqlRepo>(() => new SqlRepo());
        public static SqlRepo Instance { get { return lazy.Value; } }

        //--------------------------------------------------------------------------

        public bool ValidateAdmin(string username, string pwd)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "ValidateAdmin";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = pwd;
                    object value = cmd.ExecuteScalar();
                    if ((int)value == 1) return true;
                    else return false;
                }
            }
        }
    }
}
