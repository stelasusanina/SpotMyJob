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
	public class SectionDto
	{
		public int Id { get; set; }
		public int JobOfferId { get; set; }
		public string Name { get; set; } = null!;
		public string Content { get; set; } = null!;
	}
}
