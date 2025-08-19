using Microsoft.EntityFrameworkCore;
public class HrContext : DbContext
{
    public HrContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Employee> Employees { get; set; }
}