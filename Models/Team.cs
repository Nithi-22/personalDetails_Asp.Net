using System.ComponentModel.DataAnnotations;

using System.Web.Mvc;
namespace personaldetails.Models{
public class Team{
    //Register register=new Register();
    
     
    [Required]
    [StringLength(50)]
    public string? team_name{
        get;set;
    }
    [Key]
    public int empid{get;set;}
    public string? empemail{get;set;}
   
    public string? team_lead{
        get;
        set;
    }
     
    public string? team_manager{
        get;
        set;
    }
    
    public string? team_mem1{
        get;
        set;
    }
    
    public string? team_mem2{
        get;
        set;
    }
    
    public string? team_mem3{
        get;
        set;
    }
    
    




    
    


}}