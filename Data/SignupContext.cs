using Microsoft.EntityFrameworkCore;
using personaldetails.Models;

public class SignupContext:DbContext{
    private readonly SignupContext _context;
    public SignupContext(DbContextOptions<SignupContext>options):base(options)
        {
             
             
        }
        public DbSet<Register> SignupDetails{get;set;}
    
}
