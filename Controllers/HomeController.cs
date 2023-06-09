using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using personaldetails.Models;
using System.Collections.Generic;    
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using System.Configuration;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Web;
using Microsoft.AspNetCore.Http ;
//using Newtonsoft.Json;
using System.Security.Claims;

using System.IO;
using System.Net;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Text.RegularExpressions;


namespace personaldetails.Controllers;


public class HomeController: Controller{
   //public static DatabaseConnection login=new DatabaseConnection();
   Models.DatabaseConnection dblayer=new Models.DatabaseConnection();
   Models.DatabaseConnectionHr dblayer1=new Models.DatabaseConnectionHr();
   Register reg=new Register();
   Team team=new Team();
  
    Login login=new Login();
    HrLogin hr=new HrLogin();
    DatabaseConnection db=new DatabaseConnection(); 
    DatabaseConnectionHr dbhr=new DatabaseConnectionHr();
        private readonly IConfiguration _configuration;
    
       private readonly SignupContext _context;


    // public object CheckBox1 { get; private set; }

    public HomeController(IConfiguration configuration,SignupContext context)
    {
          _configuration = configuration;
          _context=context;
    }
    

     public IActionResult Index(){
      

        return View();
     }
     public IActionResult Personal(){
      
      return View();
     }
       public IActionResult Login( ){
     
        return View();
       }
        
          [HttpPost]
          public IActionResult Login(IFormCollection fc ){
            reg.empemail=fc["empemail"];
            int res=dblayer.LoginMtd(fc["empemail"],fc["emppass"]);

            if(res==1){
             
              HttpContext.Session.SetString("empemail",reg.empemail);
         CookieOptions option = new CookieOptions();

        option.Expires = DateTime.Now.AddDays(5);
          
         Response.Cookies.Append("empemail", $"{reg?.empemail}", option);
          Response.Cookies.Append("emppass", $"{reg?.emppass}", option);
          TempData["mail"]=reg.empemail;
          TempData.Keep("mail");
              return RedirectToAction("Success","Main");

            }
            else{
              TempData["Message"]="Login failure";
            }
            
        return View();
        }
        
       
       public IActionResult Success(){
         
         return View();
        }
      public IActionResult wrong(){
        return View();
      }
      public IActionResult HrLogin( ){
     
        return View();
       }
       [HttpPost]
          public IActionResult HrLogin(IFormCollection fc ){
            hr.email=fc["email"];
            int resu=dblayer1.LoginMethod(fc["email"],fc["pass"]);

            if(resu==1){
              
              HttpContext.Session.SetString("email",hr.email);
         CookieOptions option = new CookieOptions();

        option.Expires = DateTime.Now.AddDays(1);

         Response.Cookies.Append("email", $"{hr?.email}", option);
          Response.Cookies.Append("pass", $"{hr?.pass}", option);
              return RedirectToAction("Successhr","Main");

            }
            else{
              TempData["Messag"]="Login failure";
            }
            
        return View();
        }

        // [AcceptVerbs("Get", "Post")]
        // [AllowAnonymous]
        // public async Task<IActionResult> IsEmailInUse(string email)
        // {
        //     //check if the emailAddress already exists or not in database
        //     var user = await _context.SignupContext.Where(x => x.empemail == email).FirstOrDefaultAsync();
        //     if (user == null)
        //     {
        //         return Json(true);
        //     }
        //     else
        //     {
        //         return Json($"Email {email} is already in use");
        //     }
        // }
      
      

      
      
    

          
         
         
          
//          }





         
      
        

        
            
            
        
       
        

        
       
    

    

      
        
       
    
            
            
            // Add parameter values
            
            
            // Open connection, execute command, and close connection
            
           
    

      
      public IActionResult confirmation(){
        return View();
      }
      
      
     
}

