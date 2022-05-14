using PreciousGame.Verot.Morin.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreciousGame.Verot.Morin.Infrastructure.EntityMappings
{
    class GameFluent : EntityTypeConfiguration<Game>
    {
        public GameFluent()
        {
            ToTable("APP_JEU");

            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasColumnName("JEU_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .HasColumnName("JEU_NOM")
                .IsRequired();

            Property(e => e.Description)
                .HasColumnName("JEU_DESCRIPTION")
                .IsRequired();

            Property(e => e.ReleaseDate)
                .HasColumnName("JEU_DATESORTIE")
                .IsRequired();

            Property(e => e.KindId)
                .HasColumnName("GENRE_ID")
                .IsRequired();

            HasRequired(e => e.Kind)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.KindId);

            Property(e => e.EditorId)
              .HasColumnName("EDITEUR_ID")
              .IsRequired();

            HasRequired(e => e.Editor)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.EditorId);
        }
    }
}
