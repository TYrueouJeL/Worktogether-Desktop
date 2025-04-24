using W2G.EF;

namespace W2G.CSNL._Controllers
{
    public class BayMenu
    {
        public static BayEntity GenerateBay(string reference)
        {
            WtgContext? context = new WtgContext();
            BayEntity bay = new BayEntity();

            bay.Reference = reference;
            
            context.Add(bay);
            context.SaveChanges();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            return bay;
        }

        public static void SearchAndShowBay(string reference)
        {
            WtgContext? context = new WtgContext();
            BayEntity? bay = context.Bay.FirstOrDefault(item => item.Reference == reference);
            Console.WriteLine($"Bay : {bay.Reference} ({bay?.Units(context).Count()})");
        }

        public static void UpdateBay(BayEntity bay, string reference)
        {
            WtgContext? context = new WtgContext();
            BayEntity? bayToUpdate = context.Bay.FirstOrDefault(item => item.Id == bay.Id);
            if (bayToUpdate != null)
            {
                bayToUpdate.Reference = reference;
                context.SaveChanges();
            }
        }

        public static void DeleteBay(BayEntity bay)
        {
            WtgContext? context = new WtgContext();
            BayEntity? bayToDelete = context.Bay.FirstOrDefault(item => item.Id == bay.Id);
            if (bayToDelete != null)
            {
                context.Remove(bayToDelete);
                context.SaveChanges();
            }
        }
    }
}
