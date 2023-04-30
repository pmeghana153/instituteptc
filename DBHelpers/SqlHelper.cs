using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DbExample.DBHelpers
{
    public class SqlHelper
    {
       private readonly SqlConnection SqlConnection;
       
       public SqlHelper(string connection)
        {
            SqlConnection = new SqlConnection(connection);
            
            //SqlDataAdapter=new SqlDataAdapter();
        }
        public void InsertUpdateAndDeleteRecord(string sql, SqlParameter[] sqlParameters)
        {
            SqlCommand SqlCommand= new SqlCommand();
            SqlCommand.CommandText= sql;
            SqlCommand.Parameters.AddRange(sqlParameters);

           SqlCommand.Connection = SqlConnection;
            try
            {
                SqlConnection.Open();
                SqlCommand.ExecuteNonQuery();
                SqlConnection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public DataTable GetRecord(string sqlQuery)
        {
            SqlCommand SqlCommand = new SqlCommand();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand.CommandText = sqlQuery;
            SqlCommand.Connection = SqlConnection;
            sqlDataAdapter.SelectCommand = SqlCommand;
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }











    }
}
