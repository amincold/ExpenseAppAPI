using Microsoft.EntityFrameworkCore;

namespace ExpenseAppAPI.Model
{
    public class ExpenseAppContext:DbContext
    {
        public ExpenseAppContext(DbContextOptions<ExpenseAppContext> options):base(options) { 
        
        }

        public DbSet<Authentication> VPAuthentication { get; set; }

        public DbSet<ExpenseList> VPExpenseList { get; set; }

        public DbSet<Role> VPRole { get; set; }
        public DbSet<ChangeRequestStatus> VPChangeRequestStatus { get; set; }
        public DbSet<Expense> VPExpense { get; set; }
        public DbSet<ExpenseDetail> VPExpenseDetail { get; set; }
        public DbSet<CDNPerson> CDNPerson { get; set; }
        public DbSet<CDNPersonDetail> CDNPersonDetail { get; set; }
    }
}
