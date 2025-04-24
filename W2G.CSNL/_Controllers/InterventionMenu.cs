using W2G.EF;

namespace W2G.CSNL._Controllers
{
    public class InterventionMenu
    {
        public static InterventionEntity GenerateIntervention(string title, string description, DateTime date, TypeEntity type, UnitEntity unit)
        {
            WtgContext? context = new WtgContext();
            InterventionEntity intervention = new InterventionEntity();

            intervention.Title = title;
            intervention.Description = description;
            intervention.Date = date;
            intervention.Type = type;
            intervention.Unit = unit;

            context.Add(intervention);
            context.SaveChanges();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            return intervention;
        }

        public static void SearchAndShowIntervention(string title)
        {
            WtgContext? context = new WtgContext();
            InterventionEntity? intervention = context.Intervention.FirstOrDefault(item => item.Title == title);
            Console.WriteLine($"Intervention : {intervention.Title}");
        }
    }
}
