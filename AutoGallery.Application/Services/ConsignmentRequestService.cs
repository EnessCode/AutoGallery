using AutoGallery.Application.Interfaces.Repositories;
using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Services
{
	public class ConsignmentRequestService : IConsignmentRequestService
	{
		private readonly IConsignmentRequestRepository _repository;

		public ConsignmentRequestService(IConsignmentRequestRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<ConsignmentRequest>> GetAllRequestsAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<ConsignmentRequest> GetRequestByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task CreateRequestAsync(ConsignmentRequest request)
		{
			request.CreatedAt = DateTime.UtcNow;
			await _repository.AddAsync(request);
		}

		public async Task DeleteRequestAsync(int id)
		{
			var value = await _repository.GetByIdAsync(id);
			if (value != null)
			{
				_repository.Delete(value);
			}
		}

		public async Task ToggleStatusAsync(int id)
		{
			var value = await _repository.GetByIdAsync(id);
			if (value != null)
			{
				value.IsProcessed = !value.IsProcessed;
				_repository.Update(value);
			}
		}
	}
}
