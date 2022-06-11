using System.Data.Entity;
using System.Reflection;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.ModelLayer.Contexts
{
    public class PreciousGameContext : DbContext
    {
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Kind> Kinds { get; set; }

        public PreciousGameContext() : base("name=PreciousGameContext")
        {
            //
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            /*
            modelBuilder.Configurations.Add(new EditorFluent());
            modelBuilder.Configurations.Add(new EvaluationFluent());
            modelBuilder.Configurations.Add(new ExperienceFluent());
            modelBuilder.Configurations.Add(new GameFluent());
            modelBuilder.Configurations.Add(new KindFluent());
            */
        }
    }
}
