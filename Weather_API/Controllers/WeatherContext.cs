using Microsoft.EntityFrameworkCore;
using Weather_API.Entities;

namespace Weather_API.Controllers
{
    public class WeatherContext :DbContext
    {
       
        //override onconfog yaz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-ESBPIHB\\SQLEXPRESS ; initial catalog =API_WeatherDb;" +
                "integrated Security=true ; Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        }

        public DbSet<City> Cities { get; set; }
    }
}
