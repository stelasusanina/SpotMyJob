using SpotMyJobApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Services.Contracts
{
	public interface IHomeService
	{
		Task<IEnumerable<JobCategoryDto>> GetJobCategoriesAsync();
	}
}
