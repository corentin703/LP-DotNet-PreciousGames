using System.Data.Entity.ModelConfiguration;
using VerotMorin.PreciousGames.ModelLayer.Entities;

namespace VerotMorin.PreciousGames.ModelLayer.EntityMappings
{
    internal class EditorFluent : EntityTypeConfiguration<Editor>
    {
        public EditorFluent()
        {
            ToTable("APP_EDITEUR");

            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasColumnName("EDITEUR_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .HasColumnName("EDITEUR_NAME")
                .IsRequired();
        }
    }
}
