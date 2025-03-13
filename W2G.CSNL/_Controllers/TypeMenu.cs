using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2G.EF;
using W2G.EF._Core;

namespace W2G.CSNL._Controllers
{
    public class TypeMenu
    {
        public static TypeEntity GenerateType(string typeValue)
        {
            WtgContext? context = new WtgContext();
            TypeEntity type = new TypeEntity();

            type.Type = typeValue;

            context.Add(type);
            context.SaveChanges();

            return type;
        }

        public static void SearchAndShowType(string typeValue)
        {
            WtgContext? context = new WtgContext();
            TypeEntity? type = context.Type.FirstOrDefault(item => item.Type == typeValue);
            Console.WriteLine($"Type : {type.Type}");
        }

        public static void UpdateType(TypeEntity type, string typeValue)
        {
            WtgContext? context = new WtgContext();
            TypeEntity? typeToUpdate = context.Type.FirstOrDefault(item => item.Id == type.Id);
            if (typeToUpdate != null)
            {
                typeToUpdate.Type = typeValue;
                context.SaveChanges();
            }
        }

        public static void DeleteType(TypeEntity type)
        {
            WtgContext? context = new WtgContext();
            TypeEntity? typeToDelete = context.Type.FirstOrDefault(item => item.Id == type.Id);
            if (typeToDelete != null)
            {
                context.Remove(typeToDelete);
                context.SaveChanges();
            }
        }
    }
}
