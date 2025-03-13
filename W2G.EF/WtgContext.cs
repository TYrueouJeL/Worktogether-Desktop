using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using W2G.EF._Core;

namespace W2G.EF
{
    public class WtgContext : DbContext
    {
        public WtgContext() : base(GetDbContextOptions())
        {

        }

        public DbSet<UsageEntity>           Usage           { get; set; }
        public DbSet<TypeEntity>            Type            { get; set; }
        public DbSet<StateEntity>           State           { get; set; }
        public DbSet<BayEntity>             Bay             { get; set; }
        public DbSet<PackEntity>            Pack            { get; set; }
        public DbSet<UserEntity>            User            { get; set; }
        public DbSet<UnitEntity>            Unit            { get; set; }   
        public DbSet<InterventionEntity>    Intervention    { get; set; }
        public DbSet<OrderEntity>           Order           { get; set; }
        public DbSet<CommandedUnitEntity>   CommandedUnit   { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UsageEntity()           .OnModelCreating(modelBuilder);
            new TypeEntity()            .OnModelCreating(modelBuilder);
            new StateEntity()           .OnModelCreating(modelBuilder);
            new BayEntity()             .OnModelCreating(modelBuilder);
            new PackEntity()            .OnModelCreating(modelBuilder);
            new UserEntity()            .OnModelCreating(modelBuilder);
            new UnitEntity()            .OnModelCreating(modelBuilder);
            new InterventionEntity()    .OnModelCreating(modelBuilder);
            new OrderEntity()           .OnModelCreating(modelBuilder);
            new CommandedUnitEntity()   .OnModelCreating(modelBuilder);

            //// Récupère tous les types (classes) définis dans le projet actuel (Assembly) qui :
            //// - Sont des sous-classes de W2gEntity (donc héritent de cette classe)
            //// - Ne sont pas abstraits (on ne peut pas instancier une classe abstraite)
            //IEnumerable<Type>? entityTypes = typeof(WtgContext).Assembly.GetTypes()
            //    .Where(t => t.IsSubclassOf(typeof(WtgContext)) && !t.IsAbstract);

            //// Parcours chaque type d'entité récupéré
            ////Un type d'entité désigne une classe qui représente une table dans la base de données
            //foreach (Type type in entityTypes)
            //{
            //    // Crée une instance de l'entité (si possible) en utilisant le nom du type
            //    var instance = Activator.CreateInstance(type) as WtgContext;

            //    // Si l'instance a été créée avec succès, appelle la méthode OnModelCreating
            //    // Cela permet à chaque entité de configurer ses propres relations, contraintes, ou règles personnalisées
            //    instance?.OnModelCreating(modelBuilder);
            //}
        }

        public static DbContextOptions GetDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WtgContext>();
            optionsBuilder.UseMySQL("Server=localhost;Database=worktogether;User=root;Password=root;Port=3306");
            return optionsBuilder.Options;
        }
    }

    public abstract class WtgEntity
    {
        [Key]
        public int Id { get; set; }

        public abstract void OnModelCreating(ModelBuilder modelBuilder);
    }
}
