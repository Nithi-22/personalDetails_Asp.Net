using System.Data.SqlClient;
using System.Data;
//using Newtonsoft.Json;

namespace personaldetails.Models
{


    public class DatabaseConnection{
          static SqlConnection sqlconnection=new SqlConnection("Data Source=ELLIOT\\SQLEXPRESS;Database=db;Integrated Security=True");
           public int LoginMtd(String empemail,String emppass)
         {
                int res=0;
                 //sqlconnection.Open();
                SqlCommand command=new SqlCommand("logindetails",sqlconnection); 
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.AddWithValue("@email",empemail);
                command.Parameters.AddWithValue("@pass", emppass);
                SqlParameter oblogin=new SqlParameter();
                oblogin.ParameterName="@Isvalid";
                oblogin.SqlDbType=SqlDbType.Bit;
                oblogin.Direction=ParameterDirection.Output;
                command.Parameters.Add(oblogin);
                sqlconnection.Open();
                command.ExecuteNonQuery();
                
                 res=Convert.ToInt32(oblogin.Value);
                  sqlconnection.Close();
                  return res;
                  
                  
                  

     }
     }}

