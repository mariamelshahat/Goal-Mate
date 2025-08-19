using Goal_Mate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Goal_Mate.Configuration
{
    public class CategoryConfigure:IEntityTypeConfiguration<Category>
    {
        public void Configure ( EntityTypeBuilder<Category> builder )
        {
            builder.HasKey ( c => c.CategoryId );
            builder.Property ( c => c.Title ).IsRequired ();
        }
    }
}
