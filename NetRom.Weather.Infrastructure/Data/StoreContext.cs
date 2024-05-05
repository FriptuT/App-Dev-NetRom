using Microsoft.EntityFrameworkCore;
using NetRom.Weather.Infrastructure.Models;

namespace NetRom.Weather.Infrastructure.Data
{
    public class StoreContext: DbContext
    {


        public StoreContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<CityModel> Cities { get; set; }
    }
}
