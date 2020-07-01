using Blog.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configuration
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(x => x.FirstName).HasMaxLength(15);
			builder.Property(x => x.FirstName).IsRequired();
			builder.Property(x => x.LastName).HasMaxLength(15);
			builder.Property(x => x.LastName).IsRequired();
			builder.HasIndex(x => x.Id).IsUnique();
			builder.Property(x => x.Username).HasMaxLength(20);
			builder.Property(x => x.Username).IsRequired();
			builder.Property(x => x.Password).HasMaxLength(15);
			builder.Property(x => x.Password).IsRequired();
		}
	}
}
