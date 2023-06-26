using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using ValidationTask.Attributes;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace personaldetails.Models{
    
public class Register{
    //Register register=new Register();
    public string? emppass{
        get;set;
    }
     
    [Required(ErrorMessage = "Name is Required")]
   
    public string? emp_name{
        get;set;
    }
    [Key]
   
    public int empid{get;set;}
   [DataType(DataType.EmailAddress)]
   [EmailAddress(ErrorMessage = "Invalid email address.")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Email")]  
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
    public string? empemail{
        get;
        set;
    }
     [Required]
     [StringLength(10)]
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
    [Required(ErrorMessage ="Must be 10 digits")]
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
     [Display(Name = "Date of Birth")]
     [DataType(DataType.Date)]
    public DateTime empdob{
        get;
        set;
    }
     [Required (ErrorMessage = "Invalid joining date. " )]
     [Display(Name = "Date of Joining")]
    // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
     [DataType(DataType.Date)]
     [DateOfJoiningValidation]
    public DateTime empjoiningdate{
        get;
        set;
    }
     
    
    
    
    




    
    


}}