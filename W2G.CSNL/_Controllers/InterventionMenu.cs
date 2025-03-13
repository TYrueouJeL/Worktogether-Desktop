using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2G.EF;
using W2G.EF._Core;

namespace W2G.CSNL._Controllers
{
    public class InterventionMenu
    {
        public static InterventionEntity GenerateIntervention(TypeEntity type, UnitEntity unit, string title, string description)
        {
            WtgContext? context = new WtgContext();
            InterventionEntity intervention = new InterventionEntity();

            intervention.Type = type;
            intervention.Unit = unit;
            intervention.Title = title;
            intervention.Description = description;

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
            Console.WriteLine($"Intervention : {intervention.Title} ({intervention?.Units(context).Count()})");
        }
    }
}
