using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG200.TravelExperts.Data
{
    /*
     * Purpose: Business entity class for Packages
     * Author: Katrina Spencer
     * Date Created: 02/2021
     */
    public class Package
    {
        public int PackageId { get; set; }
        public string PkgName { get; set; }
        public DateTime? PkgStartDate { get; set; } // DBNull
        public DateTime? PkgEndDate { get; set; } // DBNull
        public string PkgDesc { get; set; } // DBNull but can't be null when modifying
        public decimal PkgBasePrice { get; set; }
        public decimal? PkgAgencyCommission { get; set; } // DBNull
    }
}
