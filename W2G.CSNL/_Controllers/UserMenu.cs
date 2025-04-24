using W2G.EF;

namespace W2G.CSNL._Controllers
{
    public class UserMenu
    {
        public static UserEntity GenerateUser(string email, string password, int role, string discr, string firstname, string lastname)
        {
            WtgContext? context = new WtgContext();
            UserEntity user = new UserEntity();

            user.Email = email;
            user.Password = password;
            user.Role = role;
            user.Discr = discr;
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
            Console.WriteLine($"User : {user.FirstName} {user.LastName} ({user.Email})");
        }

        public static void UpdateUser(UserEntity user, string email, string password, int role, string discr, string firstname, string lastname)
        {
            WtgContext? context = new WtgContext();
            user.Email = email;
            user.Password = password;
            user.Role = role;
            user.Discr = discr;
            user.FirstName = firstname;
            user.LastName = lastname;
            context.Update(user);
            context.SaveChanges();
        }

        public static void DeleteUser(UserEntity user)
        {
            WtgContext? context = new WtgContext();
            context.Remove(user);
            context.SaveChanges();
        }
    }
}
