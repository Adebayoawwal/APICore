using APICore.Container;
using Microsoft.EntityFrameworkCore;

namespace APICore.Data
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext()
        {
        }

        //this option is used to pass sql connection string details from the program.cs DI
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
            : base(options)
        {
        }
        public DbSet<CustomerService> Services { get; set; }
    }
}
