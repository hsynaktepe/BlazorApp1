using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=MealApp;Integrated Security=True;";
            var builder = new DbContextOptionsBuilder<DataContext>();

            builder.UseSqlServer(connectionString);

            return new DataContext(builder.Options);
        }
    }
}
