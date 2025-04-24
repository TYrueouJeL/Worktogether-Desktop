using W2G.EF;

namespace W2G.CSNL._Controllers
{
    public class UnitMenu
    {
        public static UnitEntity GenerateUnit(string reference, StateEntity state, BayEntity bay, UsageEntity usage)
        {
            WtgContext? context = new WtgContext();
            UnitEntity unit = new UnitEntity();

            unit.Reference = reference;
            unit.State = state;
            unit.Bay = bay;
            unit.Usage = usage;

            context.Add(unit);
            context.SaveChanges();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            return unit;
        }

        public static void SearchAndShowUnit(string reference)
        {
            WtgContext? context = new WtgContext();
            UnitEntity? unit = context.Unit.FirstOrDefault(item => item.Reference == reference);
            Console.WriteLine($"Unit : {unit.Reference}");
        }

        public static void UpdateUnit(UnitEntity unit, string reference, StateEntity state, BayEntity bay, UsageEntity usage)
        {
            WtgContext? context = new WtgContext();
            UnitEntity? unitToUpdate = context.Unit.FirstOrDefault(item => item.Id == unit.Id);
            if (unitToUpdate != null)
            {
                unitToUpdate.Reference = reference;
                unitToUpdate.State = state;
                unitToUpdate.Bay = bay;
                unitToUpdate.Usage = usage;
                context.SaveChanges();
            }
        }

        public static void DeleteUnit(UnitEntity unit)
        {
            WtgContext? context = new WtgContext();
            UnitEntity? unitToDelete = context.Unit.FirstOrDefault(item => item.Id == unit.Id);
            if (unitToDelete != null)
            {
                context.Remove(unitToDelete);
                context.SaveChanges();
            }
        }
    }
}
