using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerScaffoldedWithEF.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string AccountName { get; set; }
    }
}
