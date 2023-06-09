using System.ComponentModel.DataAnnotations;
namespace personaldetails.Models{


    
public class Login{
    
        [Required(ErrorMessage ="Please enter password")]
    [DataType(DataType.Password)]
    [StringLength(6,MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
    public string? emppass{
      get;set;
    }
    [Key]
    public int empid{get;set;}
    
      
    
      
    
    
    
   
    [Required] 
     
    public string? empemail{
        get;
        set;
    }
        public bool CheckBox1 { get; internal set; }
    }
}
