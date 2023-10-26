using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Database.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        //Название таблицы, моторое будет отобранаться в БД
        private const string TableName = "cd_student";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //Задаси первичный ключ
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            //Для целочисленного первичного клеча задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p. StudentId)
                .ValueGeneratedOnAdd();
            //Расписываеи как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.StudentId)
                    .HasColumnName("student_id")
                    .HasComment("Идентификатор записи студента");

            //HasComment добавит комментарий, иоторый будет отобраматься в СУБД (добавлять по желанно) builder Property(p => p. FirstName)
            builder.Property(p => p.FirstName)
           .IsRequired()
           .HasColumnName("c_student_firstname")
           .HasColumnType(ColumnType.String).HasMaxLength(100)
           .HasComment("Имя студента");

            builder.Property(p => p.LastName)
                    .IsRequired()
                    .HasColumnName("c_student_lastname");
        }
    }
}
