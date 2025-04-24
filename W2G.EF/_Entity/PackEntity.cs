using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace W2G.EF
{
    public class PackEntity : WtgEntity
    {
        public override string Label => Name;
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
