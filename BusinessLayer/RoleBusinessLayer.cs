using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RoleBusinessLayer
    {
        public IEnumerable<Role> Roles
        {
            get
            {
                List<Role> Roles = new List<Role>();
                SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SP_tbl_Role";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", "Select"));
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Role role = new Role();
                    role.RoleName = reader["RoleName"].ToString();
                    role.Id = Convert.ToInt64(reader["Id"].ToString());
                    Roles.Add(role);
                }
                sqlConnection1.Close();
                return Roles;
            }
        }

        public int AddCountry(Role role)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_Role";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Insert"));
            cmd.Parameters.Add(new SqlParameter("@RoleName", role.RoleName));
            cmd.Parameters.Add(new SqlParameter("@Id", role.Id));
            cmd.Parameters.Add(new SqlParameter("@CUser", role.cuser));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public int UpdateCountry(Role role)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_Role";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Update"));
            cmd.Parameters.Add(new SqlParameter("@RoleName", role.RoleName));
            cmd.Parameters.Add(new SqlParameter("@Id", role.Id));
            cmd.Parameters.Add(new SqlParameter("@UUser", role.UUser));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public int DeleteCountry(Role role)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_Role";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Delete"));
            cmd.Parameters.Add(new SqlParameter("@Id", role.Id));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }


    }
}
