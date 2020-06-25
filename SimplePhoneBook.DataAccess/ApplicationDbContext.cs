using System;
using System.Collections.Generic;
using System.Text;

using SimplePhoneBook.DataAccess.Data.Repository;
using SimplePhoneBook.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SimplePhoneBook.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Entry> Entry { get; set; }
        public DbSet<PhoneBook> PhoneBook { get; set; }



    }
}
