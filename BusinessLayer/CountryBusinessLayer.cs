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

    }
}
