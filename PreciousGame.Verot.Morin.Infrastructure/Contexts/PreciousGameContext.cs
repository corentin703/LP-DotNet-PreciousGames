using PreciousGame.Verot.Morin.Infrastructure.Entities;
using PreciousGame.Verot.Morin.Infrastructure.EntityMappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreciousGame.Verot.Morin.Infrastructure.Contexts
{
    public class PreciousGameContext : DbContext
    {
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Kind> Kinds { get; set; }

        public PreciousGameContext()
        {
            //
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Configurations.Add(new EditorFluent());
            modelBuilder.Configurations.Add(new EvaluationFluent());
            modelBuilder.Configurations.Add(new ExperienceFluent());
            modelBuilder.Configurations.Add(new GameFluent());
            modelBuilder.Configurations.Add(new KindFluent());
        }
    }
}
