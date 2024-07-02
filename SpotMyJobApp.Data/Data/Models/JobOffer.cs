using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Data.Data.Models
{
	public class JobOffer
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; } = null!;

		[Required]
		public DateTime PostedOn { get; set; }

		[Required]
		public string Country { get; set; } = null!;

		[Required]
		public string City { get; set; } = null!;

		[Required]
		public string CompanyName { get; set; } = null!;

        public string? CompanyDescription { get; set; }
        public bool IsFullTime { get; set; }

		[ForeignKey(nameof(JobCategory))]
		public int JobCategoryId { get; set; }
		public JobCategory JobCategory { get; set; } = null!;

		public ICollection<JobApplication> JobsApplications { get; set; } = new List<JobApplication>();
		public ICollection<Section> Sections { get; set; } = new List<Section>();
	}
}
