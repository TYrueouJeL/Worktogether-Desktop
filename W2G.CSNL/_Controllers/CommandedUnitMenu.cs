using W2G.EF;

namespace W2G.CSNL._Controllers
{
    public class CommandedUnitMenu
    {
        public static CommandedUnitEntity GenerateCommandedUnit(OrderEntity order, UnitEntity unit)
        {
            WtgContext? context = new WtgContext();
            CommandedUnitEntity? commandedUnit = new CommandedUnitEntity();

            commandedUnit.Order = order;
            commandedUnit.Unit = unit;

            context.Add(commandedUnit);
            context.SaveChanges();

            return commandedUnit;
        }

        public static void SearchAndShowCommandedUnit(OrderEntity order)
        {
            WtgContext? context = new WtgContext();
            CommandedUnitEntity? commandedUnit = context.CommandedUnit
                .Where(cu => cu.Order == order)
                .FirstOrDefault();
            if (commandedUnit != null)
            {
                Console.WriteLine($"CommandedUnit found : {commandedUnit.Id}");
            }
            else
            {
                Console.WriteLine("CommandedUnit not found");
            }
        }
    }
}
