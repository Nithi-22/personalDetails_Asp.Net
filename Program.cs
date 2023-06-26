
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using personaldetails.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddDbContext<SignupContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());
builder.Services.AddDbContext<TeamContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());
builder.Services.AddDbContext<TransactionContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());
builder.Services.AddDbContext<PerformanceContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var configuration = builder.Configuration;
var apiEndpoint = configuration["ApiEndpoint"];
            builder.Services.AddHttpClient("api", client =>
            {
                client.BaseAddress = new Uri(apiEndpoint);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("personaldetails/json"));
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7087/",
            ValidAudience = "personal-details",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdhksksksksbjdsbjdsjbdsbjdsbjdsbjdsbjdsbjdsbjdsbjdsbjds"))
        };
    });
             builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(options =>
                 {
                    
                     options.AccessDeniedPath = new PathString("/Home/Wrong");
                      options.LoginPath = new PathString("/Home/Login");
                      options.ReturnUrlParameter = "successPath";
                  });

builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1000);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "apipersonaldetails", Version = "v1" });
            });
            
var _logger=new LoggerConfiguration().WriteTo.File("C:\\TempData\\Logger.log",rollingInterval:RollingInterval.Day).CreateLogger();
 builder.Logging.AddSerilog(_logger);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "apipersonaldetails v1");
            });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapControllerRoute(
    name: "successPath",
    pattern: "{controller=Home}/{action=Success}/{id?}");

    // app.UseEndpoints(endpoints =>
    // {
    //     endpoints.MapControllers(); // Map attribute-routed controllers
    //     // Add other endpoints as needed
    // });
    

app.Run();
async Task<HttpResponseMessage> RetryHttpClientSendAsync(HttpClient httpClient, HttpRequestMessage request, int maxRetries, TimeSpan retryDelay)
{
    int retryCount = 0;

    while (true)
    {
        try
        {
            return await httpClient.SendAsync(request);
        }
        catch (Exception ex)
        {
            if (ex is TaskCanceledException || ex is TimeoutException)
            {
                // Retry the operation if it was canceled or timed out
                retryCount++;
                if (retryCount > maxRetries)
                {
                    // Max retries reached, throw the exception
                    throw;
                }

                // Wait for a delay before retrying
                await Task.Delay(retryDelay);
            }
            else
            {
                // It's a different exception, rethrow it
                throw;
            }
        }
    }
}

// Example usage of the custom retry logic
var httpClientFactory = app.Services.GetRequiredService<IHttpClientFactory>();
var apiClient = httpClientFactory.CreateClient("api");
var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7087/api/apipersonaldetails");

try
{
    var response = await RetryHttpClientSendAsync(apiClient, request, maxRetries: 3, retryDelay: TimeSpan.FromSeconds(1));
    // Process the response
}
catch (Exception ex)
{
    // Handle the exception or log the error
}


