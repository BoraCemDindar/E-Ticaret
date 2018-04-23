using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.DAL.Identity
{
     public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
