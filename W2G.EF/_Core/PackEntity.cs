using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2G.EF._Core
{
    public class PackEntity : WtgEntity
    {
        public string Name { get; set; }
        [Column("nbr_units")]
        public int NbrUnits { get; set; }
        public bool Enable { get; set; }
        [Column("annual_reduction_percentage")]
        public int AnnualReductionPercentage { get; set; }
        public int Price { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }
    }
}
