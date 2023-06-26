using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using personaldetails.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;

namespace personaldetails.Controllers;

 
 
public class apiController : Controller
{
    

private readonly SignupContext _con;
private readonly HttpClient _httpClient;

    

    // public EntityController(IConfiguration configuration)
    // {
    //       _configuration = configuration;
    // }
    public apiController( IHttpClientFactory httpClientFactory,SignupContext con)
    {
         
         _con = con;
          _httpClient = httpClientFactory.CreateClient();
        
        _httpClient.BaseAddress = new Uri("https://localhost:7057/");
         _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
     _httpClient.Timeout = TimeSpan.FromMinutes(5);
    }

    // [HttpPost]
    // public async Task<ActionResult<Sign>>PostEmployee(Sign sign){
    //   _context.RegDetails.Add(sign);
     
      
    //   //await _context.SaveChangesAsync();
    //   await _context.SaveChangesAsync();
    //   return (sign);
      
    // }
    
    public IActionResult apipersonaldetails()
    {
        return View();
    }
    
     [HttpPost]
    
    //  public async Task<IActionResult> apipersonaldetails(Register sign){
        
    //   var signupResponse = await _httpClient.PostAsJsonAsync("api/apipersonaldetails", sign);
    //     Console.WriteLine(signupResponse);
    //      if (signupResponse.IsSuccessStatusCode)
    //      {
    //          // Signup was successful, redirect to the login page
    //          //return RedirectToAction("Login","Home");
    //           _con.SignupDetails.Add(sign);
     
      
    // //    await _context.SaveChangesAsync();
    //    await _con.SaveChangesAsync();
    //    //return ((IActionResult)sign);
    //    TempData["showmsg"]="Successfully added";
    //    return RedirectToAction("Login","Home");
    //      }
    //      else
    //       {
    //           // Signup failed, display an error message to the user
    //          var errorMessage = await signupResponse.Content.ReadAsStringAsync();
    //          ModelState.AddModelError("", errorMessage);
    //          return View(sign);
    //      }
    //  }
    
public async Task<IActionResult> apipersonaldetails(Register sign)
        {
            try
            {
                var signupResponse = await _httpClient.PostAsJsonAsync("api/Api", sign);

                if (signupResponse.IsSuccessStatusCode)
                {
                    _con.SignupDetails.Add(sign);
                    await _con.SaveChangesAsync();
                    TempData["showmsg"] = "Successfully added";
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    var errorMessage = await signupResponse.Content.ReadAsStringAsync();
                    ModelState.AddModelError("", errorMessage);
                    return View(sign);
                }
            }
            catch (TaskCanceledException ex)
            {
                // Handle timeout exception
                ModelState.AddModelError("", "The request timed out. Please try again later.");
                // Log or handle the exception as needed
                return View(sign);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                ModelState.AddModelError("", "An error occurred while processing your request.");
                // Log or handle the exception as needed
                return View(sign);
            }
        }
    }

    
    
    

     

