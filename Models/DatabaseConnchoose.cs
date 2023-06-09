using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web.Mvc;
//using Newtonsoft.Json;

namespace personaldetails.Models
{


    public class DatabaseConnchoose{
          [DataType(DataType.EmailAddress)]
   
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]  
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
    public string? emailchoose{
        get;
        set;
    }
     }}

