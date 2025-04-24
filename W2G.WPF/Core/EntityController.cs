using MahApps.Metro.Controls;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using W2G.EF;

namespace W2G.WPF.Core
{
    public enum EFormMode
    {
        Show,
        Create,
        Edit,
    }
    public enum EBoardMode
    {
        Show,
        Single,
        Extended,
    }

    public abstract class EntityController<E> where E : WtgEntity, new()
    {
        public WtgContext Context => App.GetContext();
        public DbSet<E> DbSet => Context.Set<E>();
        protected EntityController()
        {
        }

        public abstract IFormControl<E> GetForm(EFormMode mode, E entity = null);
        public abstract IBoardControl<E> GetBoard(EBoardMode mode, string search);

        public abstract EntityPresentation<E> GetPresentedEntity(E entity);

        #region View
        public virtual E ChooseEntity(string search = null)
        {
            var board = GetBoard(EBoardMode.Single, search);
            var boardVM = board.VM;

            var window = new MetroWindow();
            window.Title = "Selection d'une entité";
            window.Content = board;

            boardVM.ChooseAction = (e) => window.Close();

            window.ShowDialog();

            return boardVM.SelectedItem;
        }


        public virtual IBoardControl<E> ShowBoard(EBoardMode mode, string search)
        {
            return GetBoard(mode, search);
        }

        /// <summary>
        /// Lance le workflow de création d'une nouvelle entité
        /// </summary>
        /// <param name="entity">entité qui sert de cadre/modèle à la création</param>
        public virtual E CreateEntity(E entity)
        {
            var form = GetForm(EFormMode.Create, entity);
            var formVM = form.VM;

            var window = new MetroWindow();
            window.Title = "Création d'une nouvelle entité";
            window.Content = form;

            formVM.Presentation.OnSave = () => window.Close();
            formVM.OnCancel = () => window.Close();

            window.ShowDialog();

            return formVM.Presentation.Entity;
        }

        /// <summary>
        /// Lance le workflow de modification d'une entité
        /// </summary>
        /// <param name="entity">entité que l'on souhaite modifier</param>
        public virtual E EditEntity(E entity)
        {
            var form = GetForm(EFormMode.Edit, entity);
            var formVM = form.VM;

            var window = new MetroWindow();
            window.Title = "Modification d'une entité";
            window.Content = form;

            formVM.Presentation.OnSave = () => window.Close();
            formVM.OnCancel = () => window.Close();

            window.ShowDialog();

            return formVM.Presentation.Entity;
        }

        /// <summary>
        /// Lance le workflow de suppression d'une entité
        /// </summary>
        /// <param name="entity">entité que l'on souhaite supprimer</param>
        public virtual bool DestroyEntity(E entity)
        {
            var result = MessageBox.Show("Voulez-vous vraiment supprimer cet élément ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (DeleteEntity(entity))
                    return true;
            }
            return false;
        }
        #endregion


        #region Model
        /// <summary>
        /// Réalise l'action en base de données pour l'insertion d'une entité
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool InsertEntity(E entity)
        {
            return entity.InsertEntity(Context);
        }

        /// <summary>
        /// Réalise l'action en base de données pour la mise à jour d'une entité
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool UpdateEntity(E entity)
        {
            return entity.UpdateEntity(Context);
        }

        /// <summary>
        /// Réalise l'action en base de données pour la suppression d'une entité
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool DeleteEntity(E entity)
        {
            return entity.DeleteEntity(Context);
        }
        #endregion
    }
}
