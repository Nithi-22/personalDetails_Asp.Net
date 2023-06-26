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
   
    // public IActionResult Success(){
    //     _logger.LogWarning("this is warning log");
    //      return View();
    // }
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
    public IActionResult SessionExpired()
    {
        
        return View();
    }
    public IActionResult Team()
    {
        var useremail1=TempData["mail"];
       var user=tc.Teamdet.Select(u=>u) ;
        return View(user);
    }
    public IActionResult Transaction()
    {
        var useremail1=TempData["mail"];
       var user=transaction.TransactionDetails.Select(u=>u) ;
        return View(user);
    }
    public IActionResult Dailyperformance()
    {
        var useremail1=TempData["mail"];
       var user=performance.performancedetails.Select(u=>u) ;
        return View(user);
    }
    public IActionResult Successhr()
    {
        
        return View();
    }
    
    public IActionResult personaldetailshr()
    {
        var useremail=TempData["mailidd"];
        TempData.Keep("mailidd");
       
       var userr=db.SignupDetails.Where(u=>u.empemail==useremail ).Select(u=>u) ;
         return View(userr);
        
    
    
    
    }



    public IActionResult teamhr()
    {
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
          TempData["TempDataKey"] = HttpContext.Session.GetString("empemail");
         
              TempData.Keep("TempDatakey");
          TempData["mailidd"]=TempData["TempDataKey"] ;
          TempData.Keep("mailidd");
           TempData["empemail"]=TempData["TempDataKey"] ;
          TempData.Keep("empemail");
          
         
         

          
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
      [HttpPost]
       public IActionResult editpersonaldetails( Register register){

        
        
          var useremail=TempData["mailidd"];
          

    
          TempData["mailidd"]=useremail;
        
       //var userr = db.SignupDetails.Where(u => u.empemail ==useremail ).Select(u=>u);
       var user = db.SignupDetails.FirstOrDefault(u => u.empemail == useremail);
       //var userr = db.SignupDetails.FirstOrDefault(u => u.empemail.Equals(useremail, StringComparison.OrdinalIgnoreCase));
      
       
       using (var transaction = db.Database.BeginTransaction())
{
    try
    {
       
    
         if(user!=null  && register.emp_name != null){
         
             user.emp_name=register.emp_name;
               user.empaddr = register.empaddr;
               user.empcity = register.empcity;
              user.empstate = register.empstate;
              user.emprole = register.emprole;
              user.empphoneno =  register.empphoneno;
               user.empjoiningdate =  register.empjoiningdate;
                user.empdob = register.empdob;
               user.empbg =  register.empbg;
               db.SaveChanges();
               
              //  return RedirectToAction("Index","Home");
         }
         transaction.Commit();
    }
    catch (Exception ex)
    {
        // Handle the exception
        transaction.Rollback();
        // Log the exception or display an error message
    }}
     TempData["showw"] = "Successfully edited";
               TempData["infoo"]="click ok";
         return View(user);
         
       }//
//        [HttpPost]
// public IActionResult editpersonaldetails(Register register){
// var useremail=TempData["mailidd"];
          

    
//           TempData["mailidd"]=useremail;
     
//         var user = db.SignupDetails.FirstOrDefault(u => u.empemail ==register.empemail);
//      if (user != null  ){
      
           
//              user.emp_name = register.emp_name;
             
//              user.empaddr = register.empaddr;
//              user.empcity = register.empcity;
//              user.empstate = register.empstate;
//              user.emprole = register.emprole;
//              user.empphoneno = register.empphoneno;
//               user.empjoiningdate = register.empjoiningdate;
//               user.empdob = register.empdob;
//              user.empbg = register.empbg;
//               db.SaveChanges();
//         TempData["showmsgg"]="Successfully edited";
//        return RedirectToAction("Index","Home");
//        //return View();
//      }
//     return View(register);
// }

       [HttpPost]
       public IActionResult editteam(Team team ){
     
            var useremail=TempData["mailidd"];
          

    
          TempData["mailidd"]=useremail;
        
       //var userr = db.SignupDetails.Where(u => u.empemail ==useremail ).Select(u=>u);
       var user = tc.Teamdet.FirstOrDefault(u => u.empemail == useremail);
       //var userr = db.SignupDetails.FirstOrDefault(u => u.empemail.Equals(useremail, StringComparison.OrdinalIgnoreCase));
      
       
       using (var transaction = tc.Database.BeginTransaction())
{
    try
    {
       
    
         if(user!=null  && team.team_name != null){
         
             user.team_name=team.team_name;
               user.team_lead = team.team_lead;
               user.team_mem1 = team.team_mem1;
              user.team_mem2 = team.team_mem2;
              user.team_mem3 = team.team_mem3;
              user.team_manager =  team.team_manager;
               
               tc.SaveChanges();
               
              //  return RedirectToAction("Index","Home");
         }
         transaction.Commit();
    }
    catch (Exception ex)
    {
        // Handle the exception
        transaction.Rollback();
        // Log the exception or display an error message
    }}
     TempData["showw"] = "Successfully edited";
               TempData["infoo"]="click ok";
         return View(user);
         
       
       }
       [HttpPost]
       public IActionResult edittransaction(Transaction transactions ){
     
           var useremail=TempData["mailidd"];
          

    
          TempData["mailidd"]=useremail;
        
       //var userr = db.SignupDetails.Where(u => u.empemail ==useremail ).Select(u=>u);
       var user = transaction.TransactionDetails.FirstOrDefault(u => u.empemail == useremail);
       //var userr = db.SignupDetails.FirstOrDefault(u => u.empemail.Equals(useremail, StringComparison.OrdinalIgnoreCase));
      
       
       using (var transactionn = transaction.Database.BeginTransaction())
{
    try
    {
       
    
         if(user!=null  && transactions.BankName != null){
         
             user.BankName=transactions.BankName;
               user.AccountNo = transactions.AccountNo;
               user.Accountholdername = transactions.Accountholdername;
              user.ifsccode = transactions.ifsccode;
              
               
               transaction.SaveChanges();
               
              //  return RedirectToAction("Index","Home");
         }
         transactionn.Commit();
    }
    catch (Exception ex)
    {
        // Handle the exception
        transactionn.Rollback();
        // Log the exception or display an error message
    }}
     TempData["showw"] = "Successfully edited";
               TempData["infoo"]="click ok";
         return View(user);
         
       }
       
       [HttpPost]
       public IActionResult editperformance( Performance perform){

     
            var useremail=TempData["mailidd"];
          

    
          TempData["mailidd"]=useremail;
        
       //var userr = db.SignupDetails.Where(u => u.empemail ==useremail ).Select(u=>u);
       var user = performance.performancedetails.FirstOrDefault(u => u.empemail == useremail);
       //var userr = db.SignupDetails.FirstOrDefault(u => u.empemail.Equals(useremail, StringComparison.OrdinalIgnoreCase));
      
       
       using (var transaction = performance.Database.BeginTransaction())
{
    try
    {
       
    
         if(user!=null  && perform.team_name != null){
         
             user.team_name=perform.team_name;
               user.team_lead = perform.team_lead;
               user.team_mem1 = perform.team_mem1;
              user.team_mem2 = perform.team_mem2;
              user.team_mem3 = perform.team_mem3;
              user.team_manager =  perform.team_manager;
               
               performance.SaveChanges();
               
              //  return RedirectToAction("Index","Home");
         }
         transaction.Commit();
    }
    catch (Exception ex)
    {
        // Handle the exception
        transaction.Rollback();
        // Log the exception or display an error message
    }}
     TempData["showw"] = "Successfully edited";
               TempData["infoo"]="click ok";
         return View(user);
         
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