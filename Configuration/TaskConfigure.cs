using Goal_Mate.Models;
//using MyTask = Goal_Mate.Models.UserTask; // alias
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Goal_Mate.Configuration
{
    public class TaskConfigure :IEntityTypeConfiguration<UserTask>
    {
        public void Configure ( EntityTypeBuilder<UserTask> builder )
        {
            builder.HasKey( t => t.TaskId );
            builder.Property ( t => t.Title ).IsRequired ();
            builder.Property ( t => t.Description ).IsRequired (false);
            builder.Property ( t => t.CreatedAt )
            .HasDefaultValueSql ( "GETDATE()" );
            builder.Property ( t => t.IsCompleted )
            .HasDefaultValue ( false );
            builder.Property ( t => t.Priority )
                .HasConversion<int> ()
                .IsRequired ()
                .HasDefaultValue ( TaskPriority.Medium );
            builder.Property ( t => t.DueDate )
                .IsRequired ( false );

            builder.HasOne ( t => t.Category )
                .WithMany ( c => c.Tasks )
                .HasForeignKey ( t => t.CategoryId );

            builder.
                HasOne ( t => t.User )
                .WithMany ( u => u.Tasks )
               .HasForeignKey ( t => t.UserId )
               .IsRequired ();
         

        }
    }
}
