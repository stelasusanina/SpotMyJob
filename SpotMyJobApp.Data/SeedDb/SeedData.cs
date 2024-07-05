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
		public JobCategory Tourism { get; set; }
		public JobCategory RealEstate { get; set; }
		public JobCategory TradeAndSales { get; set; }
		public JobCategory Restaurants { get; set; }

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
				ImageUrl = "https://img.icons8.com/?size=100&id=jWPjQhx0oPhE&format=png&color=000000"
			};

			HealthCare = new JobCategory()
			{
				Id = 2,
				Name = "Healthcare",
				ImageUrl = "https://img.icons8.com/?size=100&id=PSyk3ndz4y8Q&format=png&color=000000"
			};

			Finance = new JobCategory()
			{
				Id = 3,
				Name = "Finance",
				ImageUrl = "https://img.icons8.com/?size=100&id=gUZ2I_4-D9kf&format=png&color=000000"
			};

			Law = new JobCategory()
			{
				Id = 4,
				Name = "Law",
				ImageUrl = "https://img.icons8.com/?size=100&id=ZUwxA3fsWxzF&format=png&color=000000"
			};

			Production = new JobCategory()
			{
				Id = 5,
				Name = "Production",
				ImageUrl = "https://img.icons8.com/?size=100&id=AIDAcjXSRdJQ&format=png&color=000000"
			};

			Marketing = new JobCategory()
			{
				Id = 6,
				Name = "Marketing",
				ImageUrl = "https://img.icons8.com/?size=100&id=1nBLKCIr03wS&format=png&color=000000"
			};

			Tourism = new JobCategory()
			{
				Id = 7,
				Name = "Tourism",
				ImageUrl = "https://img.icons8.com/?size=100&id=108778&format=png&color=000000"
			};

			RealEstate = new JobCategory()
			{
				Id = 8,
				Name = "Real Estate",
				ImageUrl = "https://img.icons8.com/?size=100&id=zFSrLrSD9rtA&format=png&color=000000"
			};

			TradeAndSales = new JobCategory()
			{
				Id = 9,
				Name = "Trade & Sales",
				ImageUrl = "https://img.icons8.com/?size=100&id=119113&format=png&color=000000"
			};

			Restaurants = new JobCategory()
			{
				Id = 10,
				Name = "Restaurants",
				ImageUrl = "https://img.icons8.com/?size=100&id=ljP1BCzecHs6&format=png&color=000000"
			};
		}
	}
}
