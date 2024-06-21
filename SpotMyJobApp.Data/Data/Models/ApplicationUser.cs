﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SpotMyJobApp.Data.Models
{
	public class ApplicationUser:IdentityUser
	{
		[Required]
        public string FirstName { get; set; } = string.Empty;
		[Required]
		public string LastName { get; set; } = string.Empty;
    }
}
