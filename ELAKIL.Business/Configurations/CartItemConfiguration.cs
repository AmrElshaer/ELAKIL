using ELAKIL.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.Business.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<UserCartItem>
    {
        public void Configure(EntityTypeBuilder<UserCartItem> builder)
        {
            builder.Property(a => a.Quantity).HasDefaultValue(1);
        }
    }
}
