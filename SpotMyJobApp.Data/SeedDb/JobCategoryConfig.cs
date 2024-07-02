using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotMyJobApp.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Data.SeedDb
{
	public class JobCategoryConfig : IEntityTypeConfiguration<JobCategory>
	{
		public void Configure(EntityTypeBuilder<JobCategory> builder)
		{
			var data = new SeedData();

			builder.HasData(new JobCategory[]
			{
				data.Education,
				data.Finance,
				data.Marketing,
				data.Law,
				data.HealthCare,
				data.Production
			});
		}
	}
}
