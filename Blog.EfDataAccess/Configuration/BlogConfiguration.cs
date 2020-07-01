using Blog.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configuration
{
    public class BlogConfiguration:IEntityTypeConfiguration<Article>
    {
		public void Configure(EntityTypeBuilder<Article> builder)
		{
			builder.Property(x => x.Subject).HasMaxLength(30);
			builder.HasIndex(x => x.Id).IsUnique();
			builder.Property(x => x.Subject).IsRequired();
			builder.Property(x => x.Text).IsRequired();

			builder.HasMany(b => b.ArticlesCategories).WithOne(cb => cb.Articles).HasForeignKey(x => x.ArticlesId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
