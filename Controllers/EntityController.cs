using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using personaldetails.Models;
using System.Collections.Generic;    
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Windows;
using System.Configuration;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Web;
using Microsoft.AspNetCore.Http ;
//using RemoteValidationsInMVC.Models;
//using Newtonsoft.Json;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.AspNetCore.Authorization;
namespace personaldetails.Controllers;
[Authorize(Roles = "HR")]

public class EntityController: Controller{
   public String? labelstatus;
private readonly IConfiguration _configuration;
private readonly SignupContext _context;
Register reg=new Register();

    // public EntityController(IConfiguration configuration)
    // {
    //       _configuration = configuration;
    // }
    public EntityController( SignupContext context)
    {
          _context = context;
    }
    
     public IActionResult confirmation(){
        return View();
      }
      [AllowAnonymous] 
     public IActionResult Signup(){

          return View();
       }
      
       [AllowAnonymous] 
       [HttpPost]
    
            public async Task<IActionResult> Signup([Bind("emp_name,empemail,empphoneno,emprole,empaddr,empcity,empstate,empbg,empjoiningdate,empdob")] Register user)
          {
            
            
             if (ModelState.IsValid)
             {
               
                
                 _context.Add(user);
                 
                 
                 await _context.SaveChangesAsync();
                 
                 TempData["showmsg"]="Successfully added";
                 TempData["info"]="Kindly login by cliking on login button above";
             }
             
           
             return View();
          }  

          public IActionResult Personal(){
       
        return View( );
    }
        
          
          
        
        
          
        
        
        
        
        
 

        
        
          
        
        
        
       
    
            
            

}
