﻿using SpotMyJobApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Services.Contracts
{
	public interface IAdminService
	{
		Task AddJobOfferAsync(EditAddJobOfferDto model);
		Task<bool> DeleteJobOfferAsync(int jobOfferId);
	}
}
