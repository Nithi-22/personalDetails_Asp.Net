using Microsoft.EntityFrameworkCore;
using personaldetails.Models;

public class TransactionContext:DbContext{
    private readonly TeamContext _context;
    public TransactionContext(DbContextOptions<TransactionContext>options):base(options)
        {
             
             
        }
        public DbSet<Transaction> TransactionDetails{get;set;}
    
}
