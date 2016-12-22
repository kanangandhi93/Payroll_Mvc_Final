using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer
{
    public class CountryBusinessLayer
    {
        public Int64 Id;
        public IEnumerable<Country> countries
        {
            get
            {
                List<Country> Contries = new List<Country>();
                SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SP_tbl_Country";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", "Select"));
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Country country = new Country();
                    country.CountryName = reader["CountryName"].ToString();
                    country.Id = Convert.ToInt64(reader["Id"].ToString());
                    Contries.Add(country);
                }
                sqlConnection1.Close();
                return Contries;
            }
        }

        public int AddCountry(Country country)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_Country";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Insert"));
            cmd.Parameters.Add(new SqlParameter("@CountryName", country.CountryName));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public int UpdateCountry(Country country)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_Country";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Update"));
            cmd.Parameters.Add(new SqlParameter("@CountryName", country.CountryName));
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public int DeleteCountry(Country country)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_Country";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Delete"));
            cmd.Parameters.Add(new SqlParameter("@Id", country.Id));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public IEnumerable<Country> countriesById
        {
            get
            {
                List<Country> Contries = new List<Country>();
                SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SP_tbl_Country";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", "Select"));
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Country country = new Country();
                    country.CountryName = reader["CountryName"].ToString();
                    country.Id = Convert.ToInt64(reader["Id"].ToString());
                    Contries.Add(country);
                }
                sqlConnection1.Close();
                return Contries;
            }
        }

    }
}
