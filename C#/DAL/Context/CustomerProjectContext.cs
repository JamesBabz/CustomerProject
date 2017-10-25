using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    class CustomerProjectContext : DbContext
    {
        public CustomerProjectContext(DbContextOptions<CustomerProjectContext> options): base(options)  { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        static DbContextOptions<CustomerProjectContext> options =
            new DbContextOptionsBuilder<CustomerProjectContext>()
                .UseInMemoryDatabase("TheDB")
                .Options;

        public CustomerProjectContext() : base(options)
        {

        }

        //public DbSet<Entity> Entites { get; set; }

    }
}