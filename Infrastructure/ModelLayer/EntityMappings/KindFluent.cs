using System.Data.Entity.ModelConfiguration;
using PreciousGames.Verot.Morin.ModelLayer.Entities;

namespace PreciousGames.Verot.Morin.ModelLayer.EntityMappings
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
