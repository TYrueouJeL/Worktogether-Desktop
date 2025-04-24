using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace W2G.EF
{
    public abstract class WtgEntity
    {
        public abstract string Label { get; }

        [Key]
        public int Id { get; set; }

        public abstract void OnModelCreating(ModelBuilder modelBuilder);

        public virtual bool MatchSearch(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                return true;

            return Label.Contains(searchText);
        }

        public virtual bool InsertEntity(WtgContext ctx)
        {
            if (Id == 0)
            {

                var entry = ctx.Entry(this);

                if (entry.State == EntityState.Detached)
                    ctx.Add(this);

                return ctx.SaveChanges() > 0;
            }
            return false;
        }
        public virtual bool UpdateEntity(WtgContext ctx)
        {
            if (Id != 0)
            {

                var entry = ctx.Entry(this);

                if (entry.State == EntityState.Detached)
                    ctx.Update(this);
                else
                    entry.State = EntityState.Modified;

                return ctx.SaveChanges() > 0;
            }
            return false;
        }
        public virtual bool DeleteEntity(WtgContext ctx)
        {
            if (Id != 0)
            {
                var entry = ctx.Entry(this);

                if (entry.State == EntityState.Detached)
                    ctx.Remove(this);
                else
                    entry.State = EntityState.Deleted;

                return ctx.SaveChanges() > 0;
            }
            return false;
        }

        public virtual bool IsNew()
            => Id == 0;

        public static implicit operator int?(WtgEntity entity) => entity.Id;
    }
}
