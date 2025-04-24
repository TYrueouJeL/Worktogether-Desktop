using System.Runtime.CompilerServices;
using W2G.EF;

namespace W2G.WPF.Core
{
    public static class ValidatorTools
    {
        public static void ValidateReference<E>(EntityPresentation<E> presentation, string? value, [CallerMemberName] string property = null) where E : WtgEntity, IReferenceEntity, new()
        {
            if (string.IsNullOrEmpty(value))
            {
                presentation.AddError(property, "La référence ne peut pas être vide");
            }

            if (presentation.IsNew())
            {
                if (presentation.Controller.DbSet.Count(item => string.Equals(item.Reference, value)) > 0)
                {
                    presentation.AddError(property, "Le modèle est déjà référencé");
                }
            }
            else
            {
                if (presentation.Controller.DbSet.Count(item => item.Id != presentation.Entity.Id && string.Equals(item.Reference, value)) > 0)
                    presentation.AddError(property, "Le modèle est déjà référencé");
            }
        }
    }
}
