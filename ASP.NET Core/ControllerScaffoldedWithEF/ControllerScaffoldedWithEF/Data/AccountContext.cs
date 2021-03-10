using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerScaffoldedWithEF.Models;
using Microsoft.EntityFrameworkCore;

namespace ControllerScaffoldedWithEF.Data
{
    public class AccountContext:DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {

        }
       
        public DbSet<Account> Accounts { get; set; }
    }

}
