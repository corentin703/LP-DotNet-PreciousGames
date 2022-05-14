using PreciousGame.Verot.Morin.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreciousGame.Verot.Morin.Infrastructure.EntityMappings
{
    class EvaluationFluent : EntityTypeConfiguration<Evaluation>
    {
        public EvaluationFluent()
        {
            ToTable("APP_EVALUATION");

            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasColumnName("EVAL_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(e => e.EvaluatorName)
                .HasColumnName("EVAL_NOMEVALUATEUR")
                .IsRequired();
            
            Property(e => e.Date)
                .HasColumnName("EVAL_DATE")
                .IsRequired();

            Property(e => e.Mark)
                .HasColumnName("EVAL_NOTE")
                .IsRequired();

            Property(e => e.GameId)
                .HasColumnName("JEU_ID")
                .IsRequired();

            HasRequired(e => e.Game)
                .WithMany(e => e.Evaluations)
                .HasForeignKey(e => e.GameId);
        }
    }
}
