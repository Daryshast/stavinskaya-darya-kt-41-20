using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using stavinskaya_darya_kt_41_20.Data.Helpers;
using stavinskaya_darya_kt_41_20.Models;

namespace stavinskaya_darya_kt_41_20.Data.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "Discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder
                    .HasKey(p => p.DisciplineId)
                    .HasName($"pk_(TableName)_DisciplineId");

            builder.Property(p => p.DisciplineId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.DisciplineId)
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор дисциплины");

            builder.Property(p => p.DisciplineName)
                .IsRequired()
                .HasColumnName("c_discipline_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Наименование дисциплины");

            builder.Property(p => p.DoesExist)
                .IsRequired()
                .HasColumnName("c_discipline_doesexist")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Существует ли дисциплина");


            builder.ToTable(TableName)
                .HasOne(p => p.Direction)
                .WithMany(p => p.Disciplines)
                .HasForeignKey(p => p.DirectionId)
                .HasConstraintName("fk_f_direction_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.DirectionId, $"idx_{TableName}_fk_f_direction_id");

            builder.Navigation(p => p.Direction)
                .AutoInclude();
        }
    }
}
