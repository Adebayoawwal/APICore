using APICore.Container;
using LearnAPI.Repos.Models;
using Microsoft.EntityFrameworkCore;

namespace APICore.Repos.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext()
        {
        }

        //this option is used to pass sql connection string details from the program.cs DI
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
            : base(options)
        {
        }
        public DbSet<TblCustomer> TblCustomers { get; set; }
        public DbSet<TblMenu> tblMenus  { get; set; }
        public DbSet<TblOtpManager> tblOtpManagers  { get; set; }
        public DbSet<TblProduct> tblProducts { get; set; }
        public DbSet<TblProductimage> tblProductimages  { get; set; }
        public DbSet<TblPwdManger> tblPwdMangers  { get; set; }
        public DbSet<TblRefreshtoken>  tblRefreshtokens { get; set; }
        public DbSet<TblRole>  tblRoles { get; set; }
        public DbSet<TblRolemenumap> tblRolemenumaps{ get; set; }
        public DbSet<TblRolepermission> tblRolepermissions { get; set; }
        public DbSet<TblSubtable> tblSubtables { get; set; }
        public DbSet<TblTempuser> tblTempusers  { get; set; }
        public DbSet<TblUser> tblUsers { get; set; }


    }
}
