using Goal_Mate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Goal_Mate.Configuration
{
    public class SubTaskConfigure : IEntityTypeConfiguration<Subtask>
    {
        public void Configure(EntityTypeBuilder<Subtask> builder) {
            builder.HasKey ( s => s.SubtaskId );
            builder.Property ( s => s.Title ).IsRequired ();
        }
    }
}
