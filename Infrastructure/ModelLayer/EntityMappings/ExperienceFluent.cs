using System.Data.Entity.ModelConfiguration;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace PreciousGames.Verot.Morin.ModelLayer.EntityMappings
{
    internal class ExperienceFluent : EntityTypeConfiguration<Experience>
    {
        public ExperienceFluent()
        {
            ToTable("APP_EXPERIENCE");

            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasColumnName("EXP_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(e => e.Player)
                .HasColumnName("EXP_JOUEUR")
                .IsRequired();

            Property(e => e.PlayedTime)
                .HasColumnName("EXP_TEMPSJEU")
                .IsRequired();

            Property(e => e.Percentage)
                .HasColumnName("EXP_POURCENTAGE")
                .IsRequired();

            Property(e => e.GameId)
                .HasColumnName("JEU_ID")
                .IsRequired();

            HasRequired(e => e.Game)
                .WithMany(e => e.Experiences)
                .HasForeignKey(e => e.GameId);
        }
    }
}
