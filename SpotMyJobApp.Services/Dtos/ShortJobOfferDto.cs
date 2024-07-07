using SpotMyJobApp.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Services.Dtos
{
	public class ShortJobOfferDto
	{
		public int Id { get; set; }
		public string Title { get; set; } 
		public DateTime PostedOn { get; set; }
		public string Country { get; set; } 
		public string City { get; set; } 
		public bool IsFullTime { get; set; }
		public string CompanyImgUrl { get; set; } 
		public string JobCategory { get; set; } 
	}
}
