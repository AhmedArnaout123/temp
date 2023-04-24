using GgvCsvToSql.Models;
using Microsoft.EntityFrameworkCore;

namespace GgvCsvToSql.Infrastructure;

//dotnet ef migrations add --project GgvCsvToSql/GgvCsvToSql.csproj --startup-project GgvCsvToSql/GgvCsvToSql.csproj --output-dir "Infrastructure\Migrations" $( Get-Date -UFormat "Migration%Y%m%d%H%M%S" )
//dotnet ef database update --project  GgvCsvToSql/GgvCsvToSql.csproj --startup-project GgvCsvToSql/GgvCsvToSql.csproj
public class AppDbContext : DbContext
{
    public DbSet<AmsBookingsData> AmsBookingsDataTable { get; set; }
    
    public DbSet<AmsInventoryData> AmsInventoryDataTable { get; set; }
    
    public DbSet<OasisCompany> OasisCompanyTable { get; set; }
    
    public DbSet<OasisContractBookingsPreviousMonth> OasisContractBookingsPreviousMonthTable { get; set; }
    
    public DbSet<OasisContractInventory> OasisContractInventoryTable { get; set; }
    
    public DbSet<OasisProduct> OasisProductTable { get; set; }
    
    public DbSet<OpenVivaBookingsData> OpenVivaBookingsDataTable { get; set; }
    
    public DbSet<OpenVivaStockData> OpenVivaStockDataTable { get; set; }
}