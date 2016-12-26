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
   public class CityBusinessLayer
    {
        public IEnumerable<City> Cities
        {
            get
            {
                List<City> Cities = new List<City>();
                SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SP_tbl_City";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", "Select"));
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    City city = new City();
                    city.city = reader["City"].ToString();
                    city.Id = Convert.ToInt64(reader["Id"].ToString());
                    city.CountryId = Convert.ToInt64(reader["CountryId"].ToString());
                    city.StateId = Convert.ToInt64(reader["StateId"].ToString());
                    Cities.Add(city);
                }
                sqlConnection1.Close();
                return Cities;
            }
        }

        public int AddCity(City city)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_City";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Insert"));
            cmd.Parameters.Add(new SqlParameter("@CountryId", city.CountryId));
            cmd.Parameters.Add(new SqlParameter("@State", city.StateId));
            cmd.Parameters.Add(new SqlParameter("@City", city.city));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public int UpdateCity(City city)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_City";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Update"));
            cmd.Parameters.Add(new SqlParameter("@CountryId", city.CountryId));
            cmd.Parameters.Add(new SqlParameter("@State", city.StateId));
            cmd.Parameters.Add(new SqlParameter("@Id", city.Id));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public int DeleteCity(City city)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_City";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Delete"));
            cmd.Parameters.Add(new SqlParameter("@Id", city.Id));
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
