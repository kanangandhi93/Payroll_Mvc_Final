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
    public class CompanyDetailBusinessLayer
    {
        public IEnumerable<companydetails> Companydetails
        {
            get
            {
                List<companydetails> companydetails = new List<companydetails>();
                SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SP_tbl_Company";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", "Select"));
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    companydetails Companydetails = new companydetails();
                    Companydetails.AddressLine1 = reader["AddressLine1"].ToString();
                    Companydetails.AddressLine2 = reader["AddressLine2"].ToString();
                    Companydetails.AddressLine3 = reader["AddressLine2"].ToString();
                    Companydetails.city = reader["city"].ToString();
                    Companydetails.CompanyLogo = reader["CompanyLogo "].ToString();
                    Companydetails.CompanyName = reader["CompanyName"].ToString();
                    Companydetails.ContactNo1 = Convert.ToInt64(reader["ContactNo1"].ToString());
                    Companydetails.ContactNo2 = Convert.ToInt64(reader["ContactNo2"].ToString());
                    Companydetails.Country = reader["Country"].ToString();
                    Companydetails.CUser =Convert.ToInt64( reader["CUser"].ToString());
                    Companydetails.EmailId = reader["EmailId"].ToString();
                    Companydetails.FaxNo = Convert.ToInt64(reader["FaxNo"].ToString());
                    Companydetails.FoundedYear = reader["FoundedYear "].ToString();
                    Companydetails.Founder1 = reader["Founder1"].ToString();
                    Companydetails.Founder2 = reader["Founder2"].ToString();
                    Companydetails.Founder3 = reader["Founder3"].ToString();
                    Companydetails.Founder4 = reader["Founder4"].ToString();
                    Companydetails.Founder5 = reader["Founder5"].ToString();
                    Companydetails.potalcode = reader["potalcode"].ToString();
                    Companydetails.state = reader["state"].ToString();
                    Companydetails.UUser = Convert.ToInt64(reader["UUser"].ToString());
                    Companydetails.Id = Convert.ToInt64(reader["Id"].ToString());
                    companydetails.Add(Companydetails);
                }
                sqlConnection1.Close();
                return companydetails;
            }
        }

        public int Addcompanydetails(companydetails companydetails)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_Company";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Insert"));
        
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public int Updatecompanydetails(companydetails companydetails)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_Company";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Update"));
            cmd.Parameters.Add(new SqlParameter("@companydetailsName", companydetails.companydetailsName));
            cmd.Parameters.Add(new SqlParameter("@Id", Id));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public int Deletecompanydetails(companydetails companydetails)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_Company";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Delete"));
            cmd.Parameters.Add(new SqlParameter("@Id", companydetails.Id));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public IEnumerable<companydetails> countriesById
        {
            get
            {
                List<companydetails> Contries = new List<companydetails>();
                SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SP_tbl_Company";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", "Select"));
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    companydetails companydetails = new companydetails();
                    companydetails.companydetailsName = reader["companydetailsName"].ToString();
                    companydetails.Id = Convert.ToInt64(reader["Id"].ToString());
                    Contries.Add(companydetails);
                }
                sqlConnection1.Close();
                return Contries;
            }
        }
    }
}
