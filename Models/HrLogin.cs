using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace personaldetails.Models{


    
public class HrLogin{
    
        [Required(ErrorMessage ="Please enter password")]
    [DataType(DataType.Password)]
    [StringLength(6,MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
    public string? pass{
      get;set;
    }
    [Key]
    public int empid{get;set;}
    
    
    
      
    
      
    
    
    
   
    [Required] 
     
    public string? email{
        get;
        set;
    }
        public bool CheckBox1 { get; internal set; }
    }
}
