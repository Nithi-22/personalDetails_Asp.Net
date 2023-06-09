using Microsoft.AspNetCore.Mvc;
namespace personaldetails.Controllers;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc.RazorPages;
using personaldetails.Controllers;
using personaldetails.Models;
public class MainController : Controller
{
    Register reg=new Register();
    Team team=new Team();
    Performance perform=new Performance();
    Transaction transact=new Transaction();

    Models.DatabaseConnection dblayer=new Models.DatabaseConnection();
    private readonly ILogger<MainController> _logger;
    //DatabaseConnchoose dbchoose=new DatabaseConnchoose(); 
    Models.DatabaseConnchoose dblayer1=new Models.DatabaseConnchoose();
   private readonly SignupContext db ;
   private readonly TeamContext tc;
   
   private readonly TransactionContext transaction;
   private readonly PerformanceContext performance;
   public String? email;
   public MainController(SignupContext dbContext,TeamContext tcContext,TransactionContext transactionContext,PerformanceContext performanceContext,ILogger<MainController> logger,ILogger<HomeController> logger1){
     db=dbContext;
     tc=tcContext;
     transaction=transactionContext;
     performance=performanceContext;
     _logger=logger;
   }
    public IActionResult Success(){
        _logger.LogWarning("this is warning log");
       
        return View();
    }
    public IActionResult Personal(){
       var useremail=TempData["mail"];
      
       var user=db.SignupDetails.Where(u=>u.empemail==useremail).Select(u=>u) ;
       //var regiser=db.SignupDetails.Where(row=>row.empemail==useremail).Select(row=>row);
       
    //    if (user == null)
    // {
    //     // handle case where user is not found
    //     return NotFound();
    // }
       
       
        return View(user);
    }
    public IActionResult SessionExpired(){
        
        return View();
    }
    public IActionResult Team(){
        var useremail1=TempData["mail"];
       var user=tc.Teamdet.Select(u=>u) ;
        return View(user);
    }
    public IActionResult Transaction(){
        var useremail1=TempData["mail"];
       var user=transaction.TransactionDetails.Select(u=>u) ;
        return View(user);
    }
    public IActionResult Dailyperformance(){
        var useremail1=TempData["mail"];
       var user=performance.performancedetails.Select(u=>u) ;
        return View(user);
    }
    public IActionResult Successhr(){
        
        return View();
    }
    
    public IActionResult personaldetailshr(){
        var useremail=TempData["mailid"];
       
       var userr=db.SignupDetails.Where(u=>u.empemail==useremail ).Select(u=>u) ;
        return View(userr);
    
    
    
    }



    public IActionResult teamhr(){
        var useremail=TempData["mailid"];
      
       var userr=tc.Teamdet.Where(u=>u.empemail==useremail ).Select(u=>u) ;
        return View(userr);
       
    }
    public IActionResult transactionhr(){
        var useremail=TempData["mailid"];
      
       var userr=transaction.TransactionDetails.Where(u=>u.empemail==useremail ).Select(u=>u) ;
        return View(userr);
       
    }
    public IActionResult performancehr(){
        var useremail=TempData["mailid"];
      
       var userr=performance.performancedetails.Where(u=>u.empemail==useremail ).Select(u=>u) ;
        return View(userr);
       
    }
    
   
    public IActionResult choose( ){
     
    return View();
       }
       [HttpPost]
       
    public IActionResult choose(IFormCollection fc ){
       
        reg.empemail=fc["empemail"];
            int res=dblayer.LoginMtd(fc["empemail"],fc["emppass"]);

            if(res==1){
             
              HttpContext.Session.SetString("empemail",reg.empemail);
         CookieOptions option = new CookieOptions();

        option.Expires = DateTime.Now.AddDays(5);
          
         Response.Cookies.Append("empemail", $"{reg?.empemail}", option);
          Response.Cookies.Append("emppass", $"{reg?.emppass}", option);
          TempData["mailid"]=reg.empemail;
          TempData.Keep("mailid");
          TempData["mail"]=reg.empemail;
          TempData.Keep("mail");
          TempData["maill"]=reg.empemail;
          TempData.Keep("maill");
         TempData["m"]=reg.empemail;
         TempData.Keep("m");
          
              return RedirectToAction("personaldetailshr","Main");
              
            }
            else{
              TempData["Message"]="Login failure";
            }
            
        return View();
        }
         public IActionResult chooseteam( ){
     
            return View();
       }
       [HttpPost]
       public IActionResult chooseteam( IFormCollection fc){
         reg.empemail=fc["empemail"];
            int res=dblayer.LoginMtd(fc["empemail"],fc["emppass"]);

            if(res==1){
             
              HttpContext.Session.SetString("empemail",reg.empemail);
         CookieOptions option = new CookieOptions();

        option.Expires = DateTime.Now.AddDays(5);
          
         Response.Cookies.Append("empemail", $"{reg?.empemail}", option);
          Response.Cookies.Append("emppass", $"{reg?.emppass}", option);
          TempData["mailid"]=reg.empemail;
          TempData.Keep("mailid");
              return RedirectToAction("teamhr","Main");
              
            }
            else{
              TempData["Message"]="Login failure";
            }
            
            return View();
       }
       public IActionResult chooseperformance( ){
     
            return View();
       }
       [HttpPost]
       public IActionResult chooseperformance( IFormCollection fc){
       reg.empemail=fc["empemail"];
            int res=dblayer.LoginMtd(fc["empemail"],fc["emppass"]);

            if(res==1){
             
              HttpContext.Session.SetString("empemail",reg.empemail);
         CookieOptions option = new CookieOptions();

        option.Expires = DateTime.Now.AddDays(5);
          
         Response.Cookies.Append("empemail", $"{reg?.empemail}", option);
          Response.Cookies.Append("emppass", $"{reg?.emppass}", option);
          TempData["mailid"]=reg.empemail;
          TempData.Keep("mailid");
              return RedirectToAction("performancehr","Main");
              
            }
            else{
              TempData["Message"]="Login failure";
            }
            
            return View();
       }
       public IActionResult choosetransaction( ){
     
            return View();
       }
       [HttpPost]
       public IActionResult choosetransaction(IFormCollection fc ){
     reg.empemail=fc["empemail"];
            int res=dblayer.LoginMtd(fc["empemail"],fc["emppass"]);

            if(res==1){
             
              HttpContext.Session.SetString("empemail",reg.empemail);
         CookieOptions option = new CookieOptions();

        option.Expires = DateTime.Now.AddDays(5);
          
         Response.Cookies.Append("empemail", $"{reg?.empemail}", option);
          Response.Cookies.Append("emppass", $"{reg?.emppass}", option);
          TempData["mailid"]=reg.empemail;
          TempData.Keep("mailid");
              return RedirectToAction("transactionhr","Main");
              
            }
            else{
              TempData["Message"]="Login failure";
            }
            
            return View();
       }
      //  var useremail=TempData["mailid"];
      
      //  var userr=db.SignupDetails.Where(u=>u.empemail==useremail ).Select(u=>u) ;
      //   return View(userr);
      
       public IActionResult editpersonaldetails(Register register){

        
        var useremail= TempData["m"];
        TempData.Keep("m");
          
       var user = db.SignupDetails.Where(u => u.empemail == useremail).Select(u=> u);
       //var user = db.SignupDetails.Select(u => u.empemail == useremail);
         return View(user);
       }
       [HttpPost]
public IActionResult editpersonaldetails(Register register,IFormCollection fc){

     var useremail= TempData["m"];
        TempData.Keep("m");
   
      //var userss = db.SignupDetails.Select(u => u.empemail ==register.empemail);
        var userss = db.SignupDetails.FirstOrDefault(u => u.empemail == register.empemail);
     if (userss != null  ){
      
        
             userss.emp_name = register.emp_name;
             userss.empaddr = register.empaddr;
             userss.empcity = register.empcity;
             userss.empstate = register.empstate;
             userss.emprole = register.emprole;
             userss.empphoneno = register.empphoneno;
              userss.empjoiningdate = register.empjoiningdate;
              userss.empdob = register.empdob;
             userss.empbg = register.empbg;
              db.SaveChanges();
        TempData["showmsgg"]="Successfully edited";
       return RedirectToAction("Index","Home");
     }
    return View(userss);
}


       public IActionResult editteam( ){
     
            return View();
       }
       public IActionResult edittransaction( ){
     
            return View();
       }
       public IActionResult editperformance( ){
     
            return View();
       }



       
        

    
    
    

    
    
    

// public void Sample(){
//     //   _logger.LogTrace("this is trace log");
//     //   _logger.LogDebug("this is debug log");
//     //   _logger.LogInformation("this is info log");
//     //   _logger.LogWarning("this is warning log");
//     //   _logger.LogCritical("this is critical log");
//     //   _logger.LogError("this is logerror log");

//     }


    
}