using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Data.Data.Models
{
	public class Section
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(JobOffer))]
        public int JobOfferId { get; set; }
		public JobOffer JobOffer { get; set; } = null!;

		[Required]
		public string Content { get; set; } = null!;

    }
}
