using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2G.EF._Core
{
    public class PackEntity : WtgEntity
    {
        public string Name { get; set; }
        public int NbrUnits { get; set; }
        public bool Enabled { get; set; }
        public int AnnualReductionPercentage { get; set; }
        public int Price { get; set; }

        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //throw new NotImplementedException();
        }
    }
}
