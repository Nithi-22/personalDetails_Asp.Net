using System.ComponentModel.DataAnnotations;

using System.Web.Mvc;
namespace personaldetails.Models{
public class Transaction{
    //Register register=new Register();
    
     
   
    public string? BankName{
        get;set;
    }
    [Key]
    public int empid{get;set;}
    public string? empemail{get;set;}
    public string? AccountNo{get;set;}
   
    public string?ifsccode{get;set;}
        
    
     
    public string? Accountholdername{
        get;
        set;
    }
    
    



    
    


}}