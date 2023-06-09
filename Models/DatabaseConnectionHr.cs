using System.Data.SqlClient;
using System.Data;
//using Newtonsoft.Json;

namespace personaldetails.Models
{


    public class DatabaseConnectionHr{
          static SqlConnection sqlconnection=new SqlConnection("Data Source=ELLIOT\\SQLEXPRESS;Database=db;Integrated Security=True");
           public int LoginMethod(String email,String pass)
         {
                int resu=0;
                 //sqlconnection.Open();
                SqlCommand command=new SqlCommand("hrlogincredentials",sqlconnection); 
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.AddWithValue("@email",email);
                command.Parameters.AddWithValue("@pass", pass);
                SqlParameter oblogin=new SqlParameter();
                oblogin.ParameterName="@Isvalid";
                oblogin.SqlDbType=SqlDbType.Bit;
                oblogin.Direction=ParameterDirection.Output;
                command.Parameters.Add(oblogin);
                sqlconnection.Open();
                command.ExecuteNonQuery();
                
                 resu=Convert.ToInt32(oblogin.Value);
                  sqlconnection.Close();
                  return resu;
                  
                  
                  

     }
     }}

