using System.Data.Entity.ModelConfiguration;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.ModelLayer.EntityMappings
{
    internal class KindFluent : EntityTypeConfiguration<Kind>
    {
        public KindFluent()
        {
            ToTable("APP_GENRE");

            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasColumnName("GENRE_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .HasColumnName("GENRE_NOM")
                .IsRequired();
        }
    }
}
