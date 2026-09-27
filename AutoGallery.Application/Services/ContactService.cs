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
	public class ContactService : IContactService
	{
		private readonly IRepository<ContactMessage> _repository;

		public ContactService(IRepository<ContactMessage> repository)
		{
			_repository = repository;
		}

		public async Task SendMessageAsync(ContactMessage message)
		{
			await _repository.AddAsync(message);
		}
	}
}
