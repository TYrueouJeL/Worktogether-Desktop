using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2G.EF;
using W2G.EF._Core;

namespace W2G.CSNL._Controllers
{
    public class PackMenu
    {
        public static PackEntity GeneratePack(string name, int nbr_units, bool enable, int annual_reduction_percentage, int price)
        {
            WtgContext? context = new WtgContext();
            PackEntity pack = new PackEntity();

            pack.Name = name;
            pack.NbrUnits = nbr_units;
            pack.Enable = enable;
            pack.AnnualReductionPercentage = annual_reduction_percentage;
            pack.Price = price;

            try
            {
                context.Add(pack);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return pack;
        }

        public static void SearchAndShowPack(string name)
        {
            WtgContext? context = new WtgContext();
            PackEntity? pack = context.Pack.FirstOrDefault(item => item.Name == name);
            string status = pack.Enable ? "actif" : "inactif";
            Console.WriteLine($"Pack : {pack.Name} [{status}]");
        }
    }
}
