using Blog.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configuration
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.Property(x => x.Name).HasMaxLength(30);
			builder.HasIndex(x => x.Id).IsUnique();
			builder.Property(x => x.Name).IsRequired();

			builder.HasMany(c => c.ArticlesCategories).WithOne(bc => bc.Categories).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
