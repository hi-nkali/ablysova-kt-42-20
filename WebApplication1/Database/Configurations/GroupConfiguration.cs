using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;
using System.Text.RegularExpressions;

namespace WebApplication1.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_group";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
           

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                    .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");

            //Добавим явную автоподгрузку связанной сущности
            builder.Navigation(p => p.Group)
                    .AutoInclude();
        }
    }
}
