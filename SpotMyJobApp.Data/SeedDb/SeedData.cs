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

		public JobOffer TravelAdvisor { get; set; }
		public JobOffer MarketResearchAnalyst { get; set; }
		public JobOffer CTA {  get; set; }

		public Section Responsibilities1 { get; set; }
		public Section Requirements1 { get; set; }
		public Section Benefits1 { get; set; }

		public Section Responsibilities2 { get; set; }
		public Section Requirements2 { get; set; }
		public Section Benefits2 { get; set; }

		public Section Responsibilities3 { get; set; }
		public Section Requirements3 { get; set; }
		public Section Benefits3 { get; set; }

		public SeedData()
		{
			SeedJobCategories();
			SeedJobOffers();
			SeedSections();
		}

		private void SeedSections()
		{
			Responsibilities1 = new Section()
			{
				Id = 1,
				JobOfferId = 1,
				Name = "Responsibilities",
				Content = "Assisting clients in planning and booking their travel arrangements. Building and maintaining strong client relationships through effective communication and personalized service. Resolving any issues or concerns that arise before, during, or after travel, ensuring a seamless experience for all clients."
			};

			Requirements1 = new Section()
			{
				Id = 2,
				JobOfferId = 1,
				Name = "Requirements",
				Content = "Fluency in both German and English (written and spoken) is essential. Excellent communication and customer service skills. Ability to work independently. Basic computer knowledge."
			};

			Benefits1 = new Section()
			{
				Id = 3,
				JobOfferId = 1,
				Name = "Benefits",
				Content = "Fully remote position. Paid training and onboarding. Competitive salary and performance-based incentives. Opportunities for professional development and career growth within the company."
			};

			Responsibilities2 = new Section()
			{
				Id = 4,
				JobOfferId = 2,
				Name = "Responsibilities",
				Content = "Conduct thorough market research on commercial real estate markets, including collecting and analyzing data on various market indicators. Identify trends, patterns and correlations in the data to inform valuation decisions. Utilize statistical models and forecasting techniques to predict future market conditions and property values. Prepare market reports and presentations for clients, highlighting key findings and recommendations. Collaborate with valuation professionals to integrate market research findings into the valuation process. Ensure compliance with industry regulations, professional standards and best practices in market research activities."
			};

			Requirements2 = new Section()
			{
				Id = 5,
				JobOfferId = 2,
				Name = "Requirements",
				Content = "Master’s/Bachelor’s degree in a relevant field. 1+ years of experience in market research role. Proficiency in Microsoft Excel and PowerPoint. Fluency in English. Excellent research skills, with the ability to gather and interpret data from diverse sources. Effective communication skills, with the ability to present complex information in a clear and concise manner. Familiarity with real estate valuation methodologies and concepts will be considered an advantage."
			};

			Benefits2 = new Section()
			{
				Id = 6,
				JobOfferId = 2,
				Name = "Benefits",
				Content = "Vibrant company culture with friendly team and team events. Real estate professionals who will provide you relevant introduction and training. High ethical and professional standards. Open-minded team who will value your opinion. Opportunities for professional growth and advancement. Competitivе remuneration and additional benefits."
			};

			Responsibilities3 = new Section()
			{
				Id = 7,
				JobOfferId = 3,
				Name = "Responsibilities",
				Content = "Assist Clinical Trial Lead / Project Manager and Clinical Research Associates (CRAs) with accurately updating and maintaining clinical systems that track site compliance and performance within project timelines. Maintenance of Trial Master File - paper and electronic. Assist the clinical team in the preparation, handling, distribution, filing, and archiving of clinical documentation and reports according to the scope of work and standard operating procedures. Manage initial set up and access requests for local sponsor and trial site staff to various study systems. Assist with periodic review of study files for accuracy and completeness. Reviewing and completing central Trial Master file prior to any inspection and provision of documents during inspection. Act as a central contact for the clinical team for designated project communications, correspondence and associated documentation. Tracking and helping with ethics and health authority submissions. Strong written and verbal communication skills including good command of English language. Effective time management and organizational skills. School diploma/certificate or equivalent combination of education, training and experience. Life science degree preferred."
			};

			Requirements3 = new Section()
			{
				Id = 8,
				JobOfferId = 3,
				Name = "Requirements",
				Content = "Fluent Bulgarian and English language – both written and spoken. Basic knowledge of clinical research regulatory requirements, Good Clinical Practice (GCP) and International Conference on Harmonization (ICH) guidelines. At least 2 years of relevant experience. Adequate university degree is advantage. Problem solving skills. Results and detail-oriented approach to work delivery and output. Ability to prioritize own workloads to meet deadlines. Strong software and computer skills, including MS Office applications."
			};

			Benefits3 = new Section()
			{
				Id = 9,
				JobOfferId = 3,
				Name = "Benefits",
				Content = "Chance to work in international company. Opportunity to gain specific know-how. Competitive salary. Excellent remuneration package."
			};
		}

		private void SeedJobOffers()
		{
			TravelAdvisor = new JobOffer
			{
				Id = 1,
				Title = "Travel Advisor with German & English",
				PostedOn = new DateTime(2024, 7, 5),
				Country = "Bulgaria",
				City = "Sofia",
				CompanyName = "BAB consult",
				CompanyDescription = "As a recruiting agency, we offer you an exceptional job opportunity for a trusted client. They are a leading BPO company and are currently seeking ambitious travel enthusiasts.\r\n\r\nWith a focus on luxury and bespoke travel arrangements, they pride themselves on delivering exceptional service and creating lifelong memories for clients worldwide.",
				CompanyImgUrl = "https://babconsult.bg/themes/vreedom18-bingo-child/assets/images/logo.svg",
				IsFullTime = true,
				JobCategoryId = 7
			};

			MarketResearchAnalyst = new JobOffer
			{
				Id = 2,
				Title = "Market Research Analyst (commercial real estate)",
				PostedOn = new DateTime(2024, 7, 12),
				Country = "Bulgaria",
				City = "Sofia",
				CompanyName = "Adecco",
				CompanyImgUrl = "https://worktalent.com/web/uploads/site_users_company/11/logo/thumb_314x132_Adecco-logo-2-2.png",
				IsFullTime = true,
				JobCategoryId = 8
			};

			CTA = new JobOffer
			{
				Id = 3,
				Title = "Clinical Trial Assistant – CTA",
				PostedOn = new DateTime(2024, 6, 8),
				Country = "Romania",
				City = "Bucharest",
				CompanyName = "HT Research",
				CompanyImgUrl = "https://assets.jobs.bg/assets/logo/2015-10-21/b_55f80568ba99ec7d039e7b858410339f.png",
				IsFullTime = true,
				JobCategoryId = 2
			};
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
