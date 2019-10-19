using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_FisrtProject.Models
{
    public class AddressBookContext : DbContext
    {
        public DbSet<Contacts> Contacts { get; set; }

        public AddressBookContext(DbContextOptions<AddressBookContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

    }
}
