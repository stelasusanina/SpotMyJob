﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Services.Dtos
{
	public class QueryModel
	{
        public string? Category { get; set; }
		public string? Country { get; set; }
		public string? JobTitle { get; set;}
		public string? OrderBy { get; set;}
    }
}
