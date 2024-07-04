using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Data.Data.Models
{
	public class JobCategory
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = null!;

		[Required]
		public string ImageUrl { get; set; } = null!;
		public ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();

	}
}
