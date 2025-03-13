using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using W2G.EF;
using W2G.EF._Core;

namespace W2G.CSNL._Controllers
{
    public class UsageMenu
    {
        public static UsageEntity GenerateUsage(string type, string color)
        {
            WtgContext? context = new WtgContext();
            UsageEntity usage = new UsageEntity();

            usage.Type = type;
            usage.Color = color;

            context.Add(usage);
            context.SaveChanges();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            return usage;
        }

        public static void SearchAndShowUsage(string type)
        {
            WtgContext? context = new WtgContext();
            UsageEntity? usage = context.Usage.FirstOrDefault(item => item.Type == type);
            Console.WriteLine($"Usage : type : {usage.Type} color : {usage.Color}");
        }

        public static void UpdateUsage(UsageEntity usage, string type, string color)
        {
            WtgContext? context = new WtgContext();
            UsageEntity? usageToUpdate = context.Usage.FirstOrDefault(item => item.Id == usage.Id);
            if (usageToUpdate != null)
            {
                usageToUpdate.Type = type;
                usageToUpdate.Color = color;
                context.SaveChanges();
            }
        }

        public static void DeleteUsage(UsageEntity usage)
        {
            WtgContext? context = new WtgContext();
            UsageEntity? usageToDelete = context.Usage.FirstOrDefault(item => item.Id == usage.Id);
            if (usageToDelete != null)
            {
                context.Remove(usageToDelete);
                context.SaveChanges();
            }
        }
    }
}
