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
				Name = "Education",
				ImageUrl = "https://www.flaticon.com/free-icon/education_3976631?term=education&page=1&position=7&origin=tag&related_id=3976631"
			};

			HealthCare = new JobCategory()
			{
				Id = 2,
				Name = "Healthcare",
				ImageUrl = "https://www.flaticon.com/free-icon/healthcare_2382461?term=healthcare&page=1&position=5&origin=search&related_id=2382461"
			};

			Finance = new JobCategory()
			{
				Id = 3,
				Name = "Finance",
				ImageUrl = "https://www.flaticon.com/free-icon/budget_781831?term=finance&page=1&position=3&origin=search&related_id=781831"
			};

			Law = new JobCategory()
			{
				Id = 4,
				Name = "Law",
				ImageUrl = "https://www.flaticon.com/free-icon/compliant_4252296?term=law&page=1&position=4&origin=search&related_id=4252296"
			};

			Production = new JobCategory()
			{
				Id = 5,
				Name = "Production",
				ImageUrl = "https://www.flaticon.com/free-icon/manufacturing_2821866?term=production&page=1&position=26&origin=search&related_id=2821866"
			};

			Marketing = new JobCategory()
			{
				Id = 6,
				Name = "Marketing",
				ImageUrl = "https://www.flaticon.com/free-icon/content_9743201?term=marketing&page=1&position=39&origin=search&related_id=9743201"
			};
		}
	}
}
