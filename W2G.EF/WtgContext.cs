using Microsoft.EntityFrameworkCore;

namespace W2G.EF
{
    public class WtgContext : DbContext
    {
        public string UserName => Environment.UserName;

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

        public WtgContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySQL("Server=localhost;Database=worktogether;User=root;Password=root;Port=3306");
            
        }

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
        }
    }
}
