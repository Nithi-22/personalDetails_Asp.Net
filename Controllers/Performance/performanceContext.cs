using Microsoft.EntityFrameworkCore;
using personaldetails.Models;

public class PerformanceContext:DbContext{
    private readonly TeamContext _context;
    public PerformanceContext(DbContextOptions<PerformanceContext>options):base(options)
        {
             
             
        }
        public DbSet<Performance> performancedetails{get;set;}
    
}
