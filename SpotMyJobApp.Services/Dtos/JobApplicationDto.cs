using SpotMyJobApp.Data.Data.Models;
using SpotMyJobApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Services.Dtos
{
	public class JobApplicationDto
	{
		public int JobOfferId { get; set; }
		public string JobOfferTitle { get; set; }
		public string JobCompanyName { get; set; }
		public string ApplicationUserId { get; set; } 
		public string Status { get; set; } 
		public string UploadedFileName { get; set; } 
		public string AppliedOn { get; set; }
	}
}
