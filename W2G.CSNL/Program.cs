using System.Runtime.CompilerServices;
using W2G.EF;
using W2G.EF._Core;

namespace W2G.CSNL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello, World!");
                BayEntity bay = GenerateBay("B032");
                UnitEntity unit = GenerateUnit("B032U001");
            }
            catch (Exception e)
            {
                ConsoleTools.Debug(e);
            }
            ConsoleTools.Pause("");
        }

        #region Entity
        static UnitEntity GenerateUnit(string reference)
        {
            WtgContext? context = new WtgContext();
            UnitEntity unit = new UnitEntity();
            unit.Reference = reference;
            context.Add(unit);
            context.SaveChanges();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            return unit;
        }

        static void SearchAndShowUnit(string reference)
        {
            WtgContext? context = new WtgContext();
            context.Unit.FirstOrDefault(item => item.Reference == reference);
        }
        #endregion

        #region Bay
        static BayEntity GenerateBay(string reference)
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

        static void SearchAndShowBay(string reference)
        {
            WtgContext? context = new WtgContext();
            context.Bay.FirstOrDefault(item => item.Reference == reference);
        }
        #endregion
    }

    public static class ConsoleTools
    {
        public static void Pause(string message)
        {
            Console.Write(message + " > ");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Debug(Exception ex, [CallerMemberName] string title = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error in {title}");
            Console.ResetColor();
            Console.WriteLine(ex.Message);
            Console.ReadKey(true);
        }
    }
}
