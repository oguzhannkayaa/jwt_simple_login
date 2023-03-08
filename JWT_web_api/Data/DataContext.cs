using Microsoft.EntityFrameworkCore;

namespace JWT_web_api.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }




    }
}
