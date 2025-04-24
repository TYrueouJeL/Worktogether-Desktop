using System.Windows;
using W2G.EF;
using W2G.WPF.Core;

namespace W2G.WPF
{
    public class UnitController : EntityController<UnitEntity>
    {
        public UnitController()
        {
        }

        public override IBoardControl<UnitEntity> GetBoard(EBoardMode mode, string search)
        {
            return new UnitBoard(mode, search);
        }

        public override IFormControl<UnitEntity> GetForm(EFormMode mode, UnitEntity entity = null)
        {
            return new UnitForm(mode, entity ?? new UnitEntity());
        }

        public override EntityPresentation<UnitEntity> GetPresentedEntity(UnitEntity entity)
        {
            return new UnitPresentation(this, entity);
        }

        public override bool DestroyEntity(UnitEntity entity)
        {
            #region Check Order
            CommandedUnitEntity? last = GetLastCommand(entity);
            if (last != null)
            {
                if (last.Order.EndDate > DateTime.Now)
                {
                    MessageBox.Show("Impossible de supprimer l'unité car elle est en cours de location");
                    return false;
                }
            }
            IQueryable<CommandedUnitEntity>? list = GetCommandedUnits(entity);
            if (list.Count() > 0)
            {
                MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer l'historique de location de l'unité ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var check = true;
                    foreach (CommandedUnitEntity item in list)
                        if (!item.DeleteEntity(Context))
                            check = false;

                    if (!check)
                    {
                        MessageBox.Show("Impossible de supprimer l'historique de location de l'unité");
                        return false;
                    }
                }
                else
                    return false;
            }
            #endregion

            #region Check Intervention
            InterventionEntity? intervention = GetInterventions(entity).FirstOrDefault();
            IQueryable<InterventionEntity>? listIntervention = GetInterventions(entity);
            if (listIntervention.Count() > 0)
            {
                MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer l'historique d'intervention de l'unité ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var check = true;
                    foreach (InterventionEntity item in listIntervention)
                        if (!item.DeleteEntity(Context))
                            check = false;
                    if (!check)
                    {
                        MessageBox.Show("Impossible de supprimer l'historique d'intervention de l'unité");
                        return false;
                    }
                }
                else
                    return false;
            }
            #endregion

            return base.DestroyEntity(entity);
        }


        public IQueryable<CommandedUnitEntity> GetCommandedUnits(UnitEntity entity)
            => entity.CommandedUnits(Context);
        
        public CommandedUnitEntity GetLastCommand(UnitEntity entity)
        {
            var list = GetCommandedUnits(entity);
            return !list.Any() ? null : list.OrderByDescending(item => item.OrderId).First();
        }

        public IQueryable<InterventionEntity> GetInterventions(UnitEntity entity)
            => entity.Interventions(Context);
    }
}
