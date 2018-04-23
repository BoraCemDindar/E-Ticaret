using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Saglik.PL.Models
{
    public class cEnums
    {
        public enum SatisDurumu : byte
        {
            siparis = 1,
            odemeonay = 2,
            kargo = 3,
            teslim = 4
        }
    }
}