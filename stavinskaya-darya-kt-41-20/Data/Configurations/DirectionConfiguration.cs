using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using stavinskaya_darya_kt_41_20.Data.Helpers;
using stavinskaya_darya_kt_41_20.Models;

namespace stavinskaya_darya_kt_41_20.Data.Configurations
{
        public class DirectionConfiguration : IEntityTypeConfiguration<Direction>
        {
            private const string TableName = "Direction";

            public void Configure(EntityTypeBuilder<Direction> builder)
            {
                builder
                        .HasKey(p => p.DirectionId)
                        .HasName($"pk_(TableName)_DirectionId");

                builder.Property(p => p.DirectionId)
                    .ValueGeneratedOnAdd();

                builder.Property(p => p.DirectionId)
                    .HasColumnName("direction_id")
                    .HasComment("Идентификатор направления");

                builder.Property(p => p.DirectionName)
                    .IsRequired()
                    .HasColumnName("c_direction_name")
                    .HasColumnType(ColumnType.String).HasMaxLength(100)
                    .HasComment("Наименование направления");

            }
        }
    }
