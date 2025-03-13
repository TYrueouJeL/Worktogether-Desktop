using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2G.EF._Core;
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
            Console.WriteLine($"Unit : {unit.Reference} [{unit.Bay.Reference}]");
        }
    }
}
