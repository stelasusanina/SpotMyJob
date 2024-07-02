using SpotMyJobApp.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Data.SeedDb
{
	public class SeedData
	{
		public JobCategory Education {  get; set; }
		public JobCategory HealthCare { get; set; }
		public JobCategory Finance { get; set; }
		public JobCategory Law {  get; set; }
		public JobCategory Production { get; set; }
		public JobCategory Marketing { get; set; }

		public SeedData()
		{
			SeedJobCategories();
		}

		private void SeedJobCategories()
		{
			Education = new JobCategory()
			{
				Id = 1,
				Name = "Education"
			};

			HealthCare = new JobCategory()
			{
				Id = 2,
				Name = "Healthcare"
			};

			Finance = new JobCategory()
			{
				Id = 3,
				Name = "Finance"
			};

			Law = new JobCategory()
			{
				Id = 4,
				Name = "Law"
			};

			Production = new JobCategory()
			{
				Id = 5,
				Name = "Production"
			};

			Marketing = new JobCategory()
			{
				Id = 6,
				Name = "Marketing"
			};
		}
	}
}
