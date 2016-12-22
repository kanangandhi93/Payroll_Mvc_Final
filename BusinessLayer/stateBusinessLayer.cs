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
    class stateBusinessLayer
    {
        public Int64 Id;
        public IEnumerable<state> States
        {
            get
            {
                List<state> states = new List<state>();
                SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SP_tbl_State";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mode", "Select"));
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    state State = new state();
                    State.CountryName = reader["CountryName"].ToString();
                    State.Id = Convert.ToInt64(reader["Id"].ToString());
                    State.CountryId = Convert.ToInt64(reader["CountryId"].ToString());
                    State.State= reader["State"].ToString();
                    states.Add(State);
                }
                sqlConnection1.Close();
                return states;
            }
        }

        public int AddState(state State)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_State";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Insert"));
            cmd.Parameters.Add(new SqlParameter("@CountryId", State.CountryId));
            cmd.Parameters.Add(new SqlParameter("@State", State.State));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public int UpdateState(state State)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_State";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Update"));
            cmd.Parameters.Add(new SqlParameter("@CountryId", State.CountryId));
            cmd.Parameters.Add(new SqlParameter("@State", State.State));
            cmd.Parameters.Add(new SqlParameter("@Id", State.Id));
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            int rv = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            cmd.Dispose();
            sqlConnection1.Dispose();

            return rv;
        }

        public int DeleteState(state State)
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollContext"].ConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SP_tbl_State";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Mode", "Delete"));
            cmd.Parameters.Add(new SqlParameter("@Id", State.Id));
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
