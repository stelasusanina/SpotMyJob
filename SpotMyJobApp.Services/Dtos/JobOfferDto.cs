using SpotMyJobApp.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Services.Dtos
{
	public class JobOfferDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public DateTime PostedOn { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public bool IsFullTime { get; set; }
		public string CompanyImgUrl { get; set; }
		public string JobCategory { get; set; }
		public int JobsApplicationsCount { get; set; }
		public ICollection<SectionDto> Sections { get; set; } = new List<SectionDto>();
	}
}

