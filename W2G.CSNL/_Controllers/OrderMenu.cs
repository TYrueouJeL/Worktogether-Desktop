using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2G.EF;
using W2G.EF._Core;

namespace W2G.CSNL._Controllers
{
    public class OrderMenu
    {
        public static OrderEntity GenerateOrder(UserEntity user, PackEntity pack, DateTime start_date, DateTime end_date, bool is_annual, int duration, int price)
        {
            WtgContext? context = new WtgContext();
            OrderEntity order = new OrderEntity();

            order.User = user;
            order.Pack = pack;
            order.StartDate = start_date;
            order.EndDate = end_date;
            order.IsAnnual = is_annual;
            order.Duration = duration;
            order.Price = price;

            context.Add(order);
            context.SaveChanges();
            
            return order;
        }

        public static void SearchAndShowOrder(string pack_name)
        {
            WtgContext? context = new WtgContext();
            PackEntity pack = context.Pack.FirstOrDefault(p => p.Name == pack_name);
            OrderEntity order = context.Order.FirstOrDefault(o => o.Pack == pack);
            Console.WriteLine(order);
        }
    }
}
