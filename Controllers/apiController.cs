using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using personaldetails.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net;

namespace personaldetails.Controllers;

 
 
public class apiController : Controller
{
    

private readonly SignupContext _con;
private readonly HttpClient _httpClient;

    

    // public EntityController(IConfiguration configuration)
    // {
    //       _configuration = configuration;
    // }
    public apiController( IHttpClientFactory httpClientFactory)
    {
         
         
          _httpClient = httpClientFactory.CreateClient();
         
        _httpClient.BaseAddress = new Uri("https://localhost:7057/");
    }
    // [HttpPost]
    // public async Task<ActionResult<Sign>>PostEmployee(Sign sign){
    //   _context.RegDetails.Add(sign);
     
      
    //   //await _context.SaveChangesAsync();
    //   await _context.SaveChangesAsync();
    //   return (sign);
      
    // }
    [HttpGet]
    public IActionResult apipersonaldetails()
    {
        return View();
    }
    
     [HttpPost]
    
     public async Task<IActionResult> apipersonaldetails(Register sign){
        
      var signupResponse = await _httpClient.PostAsJsonAsync("/signup", sign);
        Console.WriteLine(signupResponse);
         if (signupResponse.IsSuccessStatusCode)
         {
             // Signup was successful, redirect to the login page
             //return RedirectToAction("Login","Home");
              //_con.SignupDetails.Add(sign);
     
      
       //await _context.SaveChangesAsync();
       //await _con.SaveChangesAsync();
       //return (sign);
       //TempData["showmsg"]="Successfully added";
       return RedirectToAction("Login","Home");
         }
         else
          {
              // Signup failed, display an error message to the user
             var errorMessage = await signupResponse.Content.ReadAsStringAsync();
             ModelState.AddModelError("", errorMessage);
             return View(sign);
         }
     }
    


    }
    
    

     

