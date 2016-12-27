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
                    Companydetails.AddressLine3 = reader["AddressLine3"].ToString();
                    Companydetails.city = reader["city"].ToString();
                    Companydetails.CompanyLogo = reader["CompanyLogo"].ToString();
                    Companydetails.CompanyName = reader["CompanyName"].ToString();
                    Companydetails.ContactNo1 = Convert.ToInt64(reader["ContactNo1"].ToString());
                    Companydetails.ContactNo2 = Convert.ToInt64(reader["ContactNo2"].ToString());
                    Companydetails.Country = reader["Country"].ToString();
                    Companydetails.EmailId = reader["EmailId"].ToString();
                    Companydetails.FaxNo = Convert.ToInt64(reader["FaxNo"].ToString());
                    Companydetails.FoundedYear = reader["FoundedYear"].ToString();
                    Companydetails.Founder1 = reader["Founder1"].ToString();
                    Companydetails.Founder2 = reader["Founder2"].ToString();
                    Companydetails.Founder3 = reader["Founder3"].ToString();
                    Companydetails.Founder4 = reader["Founder4"].ToString();
                    Companydetails.Founder5 = reader["Founder5"].ToString();
                    Companydetails.potalcode = reader["PostalCode"].ToString();
                    Companydetails.state = reader["state"].ToString();
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
            cmd.Parameters.Add(new SqlParameter("@AddressLine1", companydetails.AddressLine1));
            cmd.Parameters.Add(new SqlParameter("@AddressLine2", companydetails.AddressLine2));
            cmd.Parameters.Add(new SqlParameter("@AddressLine3", companydetails.AddressLine3));
            cmd.Parameters.Add(new SqlParameter("@city", companydetails.city));
            cmd.Parameters.Add(new SqlParameter("@CompanyLogo", companydetails.CompanyLogo));
            cmd.Parameters.Add(new SqlParameter("@CompanyName", companydetails.CompanyName));
            cmd.Parameters.Add(new SqlParameter("@ContactNo1", companydetails.ContactNo1));
            cmd.Parameters.Add(new SqlParameter("@ContactNo2", companydetails.ContactNo2));
            cmd.Parameters.Add(new SqlParameter("@Country", companydetails.Country));
            cmd.Parameters.Add(new SqlParameter("@CUser", companydetails.CUser));
            cmd.Parameters.Add(new SqlParameter("@EmailId", companydetails.EmailId));
            cmd.Parameters.Add(new SqlParameter("@FaxNo", companydetails.FaxNo));
            cmd.Parameters.Add(new SqlParameter("@FoundedYear", companydetails.FoundedYear));
            cmd.Parameters.Add(new SqlParameter("@Founder1", companydetails.Founder1));
            cmd.Parameters.Add(new SqlParameter("@Founder2", companydetails.Founder2));
            cmd.Parameters.Add(new SqlParameter("@Founder3", companydetails.Founder3));
            cmd.Parameters.Add(new SqlParameter("@Founder4", companydetails.Founder4));
            cmd.Parameters.Add(new SqlParameter("@Founder5", companydetails.Founder5));
            cmd.Parameters.Add(new SqlParameter("@PostalCode", companydetails.potalcode));
            cmd.Parameters.Add(new SqlParameter("@state", companydetails.state));

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
            cmd.Parameters.Add(new SqlParameter("@AddressLine1", companydetails.AddressLine1));
            cmd.Parameters.Add(new SqlParameter("@AddressLine2", companydetails.AddressLine2));
            cmd.Parameters.Add(new SqlParameter("@AddressLine3", companydetails.AddressLine3));
            cmd.Parameters.Add(new SqlParameter("@city", companydetails.city));
            cmd.Parameters.Add(new SqlParameter("@CompanyLogo", companydetails.CompanyLogo));
            cmd.Parameters.Add(new SqlParameter("@CompanyName", companydetails.CompanyName));
            cmd.Parameters.Add(new SqlParameter("@ContactNo1", companydetails.ContactNo1));
            cmd.Parameters.Add(new SqlParameter("@ContactNo2", companydetails.ContactNo2));
            cmd.Parameters.Add(new SqlParameter("@Country", companydetails.Country));
            cmd.Parameters.Add(new SqlParameter("@UUser", companydetails.UUser));
            cmd.Parameters.Add(new SqlParameter("@EmailId", companydetails.EmailId));
            cmd.Parameters.Add(new SqlParameter("@FaxNo", companydetails.FaxNo));
            cmd.Parameters.Add(new SqlParameter("@FoundedYear", companydetails.FoundedYear));
            cmd.Parameters.Add(new SqlParameter("@Founder1", companydetails.Founder1));
            cmd.Parameters.Add(new SqlParameter("@Founder2", companydetails.Founder2));
            cmd.Parameters.Add(new SqlParameter("@Founder3", companydetails.Founder3));
            cmd.Parameters.Add(new SqlParameter("@Founder4", companydetails.Founder4));
            cmd.Parameters.Add(new SqlParameter("@Founder5", companydetails.Founder5));
            cmd.Parameters.Add(new SqlParameter("@PostalCode", companydetails.potalcode));
            cmd.Parameters.Add(new SqlParameter("@state", companydetails.state));
            cmd.Parameters.Add(new SqlParameter("@Id", companydetails.Id));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public int UpdatecompanyLogo(companydetails companydetails)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_Company";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "UpdateLogo"));
            cmd.Parameters.Add(new SqlParameter("@CompanyLogo", companydetails.CompanyLogo));
            cmd.Parameters.Add(new SqlParameter("@Id", companydetails.Id));
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

      
    }
}
