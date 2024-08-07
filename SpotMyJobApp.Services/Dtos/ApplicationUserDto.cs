﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Services.Dtos
{
	public class ApplicationUserDto
	{
        public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber {  get; set; }
		public string Email { get; set; }
		public string ProfilePictureUrl { get; set; }
		public IEnumerable<JobApplicationDto> JobsApplications { get; set; }
    }
}
