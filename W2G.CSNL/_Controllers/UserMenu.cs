using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using W2G.EF;
using W2G.EF._Core;

namespace W2G.CSNL._Controllers
{
    public class UserMenu
    {
        public static UserEntity GenerateUser(string email, string password, string role, string firstname, string lastname)
        {
            WtgContext? context = new WtgContext();
            UserEntity user = new UserEntity();

            user.Email = email;
            user.Password = password;
            user.Role = role;
            user.FirstName = firstname;
            user.LastName = lastname;

            context.Add(user);
            context.SaveChanges();

            return user;
        }

        public static void SearchAndShowUser(string email)
        {
            WtgContext? context = new WtgContext();
            UserEntity? user = context.User.FirstOrDefault(item => item.Email == email);
            Console.WriteLine($"User : {user.Email} ({user?.Role})");
        }
    }
}
