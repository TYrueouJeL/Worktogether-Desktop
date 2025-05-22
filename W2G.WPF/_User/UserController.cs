using System.Windows;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    public class UserController : EntityController<UserEntity>
    {
        public UserController()
        {
        }

        public override IBoardControl<UserEntity> GetBoard(EBoardMode mode, string search)
        {
            return new UserBoard(mode, search);
        }

        public override IFormControl<UserEntity> GetForm(EFormMode mode, UserEntity entity = null)
        {
            return new UserForm(mode, entity ?? new UserEntity());
        }

        public override EntityPresentation<UserEntity> GetPresentedEntity(UserEntity entity)
        {
            return new UserPresentation(this, entity);
        }

        public override bool DestroyEntity(UserEntity entity)
        {
            #region Check Order
            // Vérifie si l'utilisateur a déjà passé une commande
            bool hasOrders = Context.Order.Any(o => o.UserId == entity.Id);
            if (hasOrders)
            {
                MessageBox.Show("Impossible de supprimer cet utilisateur : il a déjà passé une ou plusieurs commandes.", "Suppression impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            #endregion

            // Suppression si aucune commande trouvée
            return base.DestroyEntity(entity);
        }
    }
}
