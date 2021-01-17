using mediatR.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mediatR.DataAccess.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {

            builder.HasKey(e => e.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}