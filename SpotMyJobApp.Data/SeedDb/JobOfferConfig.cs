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
	public class JobOfferConfig : IEntityTypeConfiguration<JobOffer>
	{
		public void Configure(EntityTypeBuilder<JobOffer> builder)
		{
			var data = new SeedData();

			builder.HasData(new JobOffer[]
			{
				data.MarketResearchAnalyst,
				data.CTA,
				data.TravelAdvisor
			});
		}
	}
}
