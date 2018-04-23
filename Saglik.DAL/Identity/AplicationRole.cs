using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.DAL.Identity
{
    public class AplicationRole : IdentityRole
    {
        public string Description { get; set; }
        public AplicationRole()
        {

        }
        public AplicationRole(string rolName, string description) : base (rolName)
        {
            this.Description = description;
        }
    }
}
