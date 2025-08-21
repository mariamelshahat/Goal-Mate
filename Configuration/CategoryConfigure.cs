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
            builder.HasData (
                new Category { CategoryId = 1, Title = "Work" },
                new Category { CategoryId = 2, Title = "Study" },
                new Category { CategoryId = 3, Title = "Personal" },
                new Category { CategoryId = 4, Title = "Shopping" },
                new Category { CategoryId = 5, Title = "Event" },
                new Category { CategoryId = 6, Title = "Entertainment" },
                new Category { CategoryId = 7, Title = "Birthday" }


            );
        }
    }
}
