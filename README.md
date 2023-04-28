# Quick Start
*   New ASP.NET Core Web API project
*   Create a new .NET 5.0 application and copy over the Program.cs and Startup.cs files, updating the namespace
*   Add database Connection String to appsettings.Develop.json, updating connection string with database name
```    
"ConnectionStrings": {
      "Default": "Server=localhost\\SQLEXPRESS;Database=DatabaseName;Trusted_Connection=True;"
    }
```
*   Create table models
*   Install Microsoft.EntityFrameworkCore.SqlServer
*   Create database context using pre-set code (sets the name of the table for table model)
```
using Microsoft.EntityFrameworkCore;
namespace PracticeReleaseReportService
{
    public class ReportsDbContext : DbContext
    {
        public ReportsDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<TableModelName> DatabaseTableName { get; set; }
    }
}
```
*   Add the following line under "servers.AddControllers();" in Startup.cs, updating the name of the database context file name
```
services.AddDbContext<DatabaseContextName>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
```
*   Add a new scaffolded API Controller with actions, using Entity Framework
*   Open the package manager console
    *   tools -> NuGet package manager -> package manager console
*   To create a new migration to update the database, run the following command, updating the name of the migration file and the project name
```
dotnet ef migrations add DatabaseContextNameMigrations --project ProjectName
```
*   Then run the following command to push your migrations to the database, updating the project name
```
dotnet ef database update --project ProjectName
```
*   If these commands don't work, check the notes from the original C# entity practice database to make sure everything is properly installed or you might need to manually create a database in Microsoft SQL server first
*   Then, you should be able to run your queries in Insomnia or Swagger