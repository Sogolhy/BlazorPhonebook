
using Contact.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.Repository.Context
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options):base(options)
        {
        }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
    }

}
