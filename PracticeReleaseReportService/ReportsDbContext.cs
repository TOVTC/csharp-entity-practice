using Microsoft.EntityFrameworkCore;
namespace PracticeReleaseReportService
{
    public class ReportsDbContext : DbContext
    {
        public ReportsDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<ReleaseReport> ReleaseReports { get; set; }
    }
}
