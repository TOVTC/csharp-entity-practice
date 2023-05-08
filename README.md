# Quick Start
*   New ASP.NET Core Web API project
*   Install Microsoft.EntityFrameworkCore
*   Install Microsoft.EntityFrameworkCore.SqlServer
*   Install Microsoft.EntityFrameworkCore.Design
*   Add database Connection String to appsettings.Develop.json, updating connection string with database name
```    
"ConnectionStrings": {
      "Default": "Server=localhost\\SQLEXPRESS;Database=DatabaseName;Trusted_Connection=True;"
    }
```
## Version 1 - Program.cs + Startup.cs
*   Create a new .NET 5.0 application and copy over the Program.cs and Startup.cs files, updating the namespace
*   Add the following line under "servers.AddControllers();" in Startup.cs, updating the name of the database context file name
```
services.AddDbContext<DatabaseContextName>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
```
## Version 2 - Program.cs
*   Add the following line under "builder.Services.AddControllers();" in Startup.cs, updating the name of the database context file name
```
builder.Services.AddDbContext<DatabaseContextName>(options => 
      options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
```
##
*   Create table models
*   Create database context using pre-set code (sets the name of the table for table model), updating database context name, table model names, and table names
```
using Microsoft.EntityFrameworkCore;
namespace PracticeReleaseReportService
{
    public class DbContextName : DbContext
    {
        public DbContextName(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<TableModelName> DatabaseTableName { get; set; }
    }
}
```
*   Add a new scaffolded API Controller with actions, using Entity Framework
*   Open the package manager console
    *   tools -> NuGet package manager -> package manager console
*   To create a new migration to update the database, run the following command, updating the name of the migration file and the project name
```
dotnet ef migrations add NameOfMigration --project ProjectName
```
*   Then run the following command to push your migrations to the database, updating the project name
```
dotnet ef database update --project ProjectName
```
*   If these commands don't work, check the notes from the original C# entity practice database to make sure everything is properly installed
*   Run your queries in Insomnia or Swagger
*   To undo a migration, use the following command to revert changes to the database, updating for the project name and name of the migration at the state you want to revert to, excluding the migration name's date
```
dotnet ef database update NameOfTargetMigration --project ProjectName
```
*   To remove the last migration, use the following command, updating project name
```
dotnet ef migrations remove --project ProjectName
```
