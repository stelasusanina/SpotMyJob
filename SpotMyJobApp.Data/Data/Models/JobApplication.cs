using SpotMyJobApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Data.Data.Models
{
	public class JobApplication
	{
        [ForeignKey(nameof(JobOffer))]
        public int JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; } = null!;
        public ApplicationUser Applicant { get; set; } = null!;

        [Required]
        public string Status { get; set; } = null!;

        [Required]
        public string UploadedFileName { get; set; } = null!;

        [Required]
        public DateTime AppliedOn { get; set; }
	}
}
