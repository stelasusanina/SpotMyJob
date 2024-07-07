using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Data.SeedDb
{
	public class SectionConfig : IEntityTypeConfiguration<Section>
	{
		public void Configure(EntityTypeBuilder<Section> builder)
		{
			var data = new SeedData();

			builder.HasData(new Section[]
			{
				data.Responsibilities1,
				data.Responsibilities2,
				data.Responsibilities3,
				data.Requirements1,
				data.Requirements2,
				data.Requirements3,
				data.Benefits1,
				data.Benefits2,
				data.Benefits3
			});
		}
	}
}
