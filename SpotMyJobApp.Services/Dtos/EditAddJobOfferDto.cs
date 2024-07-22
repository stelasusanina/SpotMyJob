using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Services.Dtos
{
	public class EditAddJobOfferDto
	{
		public string Title { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public bool IsFullTime { get; set; }
		public string CompanyName { get; set; }
		public string? CompanyDescription { get; set; }
		public string CompanyImgUrl { get; set; }
		public int JobCategoryId { get; set; }
		public int JobApplicationsCount { get; set; }
		public ICollection<SectionDto> Sections { get; set; } = new List<SectionDto>();
	}
}
