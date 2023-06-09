using Microsoft.EntityFrameworkCore;
using personaldetails.Models;

public class TeamContext:DbContext{
    private readonly TeamContext _context;
    public TeamContext(DbContextOptions<TeamContext>options):base(options)
        {
             
             
        }
        public DbSet<Team> Teamdet{get;set;}
    
}
