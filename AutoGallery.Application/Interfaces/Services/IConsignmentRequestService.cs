using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Interfaces.Services
{
	public interface IConsignmentRequestService
	{
		Task<List<ConsignmentRequest>> GetAllRequestsAsync();
		Task<ConsignmentRequest> GetRequestByIdAsync(int id);
		Task CreateRequestAsync(ConsignmentRequest request);
		Task DeleteRequestAsync(int id);
		Task ToggleStatusAsync(int id);
	}
}
