using PreciousGame.Verot.Morin.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreciousGame.Verot.Morin.Infrastructure.EntityMappings
{
    class KindFluent : EntityTypeConfiguration<Kind>
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
