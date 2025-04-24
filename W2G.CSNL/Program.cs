using System.Runtime.CompilerServices;
using W2G.CSNL._Controllers;
using W2G.EF;

namespace W2G.CSNL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UsageEntity usage = UsageMenu.GenerateUsage("Stockage", "#ffff00");
                UsageMenu.SearchAndShowUsage("Stockage");
                UsageMenu.UpdateUsage(usage, "Hébergement", "#00ffff");
                UsageMenu.SearchAndShowUsage("Hébergement");
                UsageMenu.DeleteUsage(usage);

                TypeEntity type = TypeMenu.GenerateType("Type 3");
                TypeMenu.SearchAndShowType("Type 3");
                TypeMenu.UpdateType(type, "Type 4");
                TypeMenu.SearchAndShowType("Type 4");
                TypeMenu.DeleteType(type);

                StateEntity state = StateMenu.GenerateState("Attente");
                StateMenu.SearchAndShowState("Attente");
                StateMenu.UpdateState(state, "En cours");
                StateMenu.SearchAndShowState("En cours");
                StateMenu.DeleteState(state);

                BayEntity bay = BayMenu.GenerateBay("B031");
                BayMenu.SearchAndShowBay("B031");
                BayMenu.UpdateBay(bay, "B032");
                BayMenu.SearchAndShowBay("B032");
                BayMenu.DeleteBay(bay);

                PackEntity pack = PackMenu.GeneratePack("Pack Particulier", 5, false, 25, 50);
                PackMenu.SearchAndShowPack("Pack Particulier");
                PackMenu.UpdatePack(pack, "Pack Nul", 7, true, 30, 55);
                PackMenu.SearchAndShowPack("Pack Nul");
                PackMenu.DeletePack(pack);

                UserEntity user = UserMenu.GenerateUser("user@user.com", "testtest", 1, "customer", "UserFirstName", "UserLastName");
                UserMenu.SearchAndShowUser("user@user.com");
                UserMenu.UpdateUser(user, "user2@user2.com", "test2test2", 1, "customer", "User2FirstName", "User2LastName");
                UserMenu.SearchAndShowUser("user2@user2.com");
                UserMenu.DeleteUser(user);

                UnitEntity unit = UnitMenu.GenerateUnit("B032U001", state, bay, usage);
                UnitMenu.SearchAndShowUnit("B032U001");
                UnitMenu.UpdateUnit(unit, "B032U002", state, bay, usage);
                UnitMenu.SearchAndShowUnit("B032U002");
                UnitMenu.DeleteUnit(unit);

                //InterventionEntity intervention = InterventionMenu.GenerateIntervention("Intervention 10", "Description 10", new DateTime(), type, unit);
                //InterventionMenu.SearchAndShowIntervention("Intervention 10");


                //InterventionMenu.SearchAndShowIntervention("Intervention 1");

                //var start_date = new System.DateTime(2025, 13, 03);
                //var end_date = new System.DateTime(2025, 14, 03);

                //OrderEntity order = OrderMenu.GenerateOrder(user, pack, start_date, end_date, false, 1, 50);
                //OrderMenu.SearchAndShowOrder("Pack Base");

                //CommandedUnitEntity commandedUnit = CommandedUnitMenu.GenerateCommandedUnit(order, unit);
                //CommandedUnitMenu.SearchAndShowCommandedUnit(order);
            }
            catch (Exception e)
            {
                ConsoleTools.Debug(e);
            }
            ConsoleTools.Pause("");
        }
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
