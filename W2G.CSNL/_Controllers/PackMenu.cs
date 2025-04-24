using W2G.EF;

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

        public static void UpdatePack(PackEntity pack, string name, int nbr_units, bool enable, int annual_reduction_percentage, int price)
        {
            WtgContext? context = new WtgContext();
            PackEntity? packToUpdate = context.Pack.FirstOrDefault(item => item.Id == pack.Id);
            if (packToUpdate != null)
            {
                packToUpdate.Name = name;
                packToUpdate.NbrUnits = nbr_units;
                packToUpdate.Enable = enable;
                packToUpdate.AnnualReductionPercentage = annual_reduction_percentage;
                packToUpdate.Price = price;
                context.SaveChanges();
            }
        }

        public static void DeletePack(PackEntity pack)
        {
            WtgContext? context = new WtgContext();
            PackEntity? packToDelete = context.Pack.FirstOrDefault(item => item.Id == pack.Id);
            if (packToDelete != null)
            {
                context.Remove(packToDelete);
                context.SaveChanges();
            }
        }
    }
}
