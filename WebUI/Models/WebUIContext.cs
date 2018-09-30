using System;
using Microsoft.EntityFrameworkCore;
using WebUI.Models;

namespace WebUI.Models
{
    public class WebUIContext : DbContext
    {
        public WebUIContext(DbContextOptions<WebUIContext> options) : base(options)
        {
        }

        public DbSet<WebUI.Models.Customer> Customer { get; set; }
    }
}
