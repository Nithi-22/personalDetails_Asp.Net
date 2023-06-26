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
//using Newtonsoft.Json ;
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
namespace personaldetails.Controllers;

public class TeamController: Controller{
   public String? labelstatus;
private readonly IConfiguration _configuration;
private readonly TeamContext _context;

    // public EntityController(IConfiguration configuration)
    // {
    //       _configuration = configuration;
    // }
    public TeamController( TeamContext context)
    {
          _context = context;
    }
}
     