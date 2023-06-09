using System.ComponentModel.DataAnnotations;

using System.Web.Mvc;
namespace personaldetails.Models{
public class Register{
    //Register register=new Register();
    public int emppass{
        get;set;
    }
     
    [Required]
    [StringLength(50)]
    public string? emp_name{
        get;set;
    }
    [Key]
    public int empid{get;set;}
   [DataType(DataType.EmailAddress)]
   
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]  
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
    public string? empemail{
        get;
        set;
    }
     [Required]
     [DataType(DataType.PhoneNumber)]
    public string? empphoneno{
        get;
        set;
    }
    [Required]
    [StringLength(25)]
    public string? emprole{
        get;
        set;
    }
    [Required]
    [StringLength(50)]
    public string? empaddr{
        get;
        set;
    }
    [Required]
    [StringLength(20)]
    public string? empcity{
        get;
        set;
    }
    [Required]
    [StringLength(20)]

    public string? empstate{
        get;
        set;
    }
    [Required]
    [StringLength(10)]
    public string? empbg{
        get;
        set;
    }
     [Required]
     
    public DateTime empjoiningdate{
        get;
        set;
    }
     [Required]
     
    public DateTime empdob{
        get;
        set;
    }
    
    
    
    




    
    


}}