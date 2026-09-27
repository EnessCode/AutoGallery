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

		public async Task<List<ContactMessage>> GetAllMessagesAsync()
		{
			var messages = await _repository.GetAllAsync();
			return messages.OrderByDescending(x => x.CreatedAt).ToList();
		}

		public async Task<ContactMessage> GetMessageByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task MarkAsReadAsync(int id)
		{
			var message = await _repository.GetByIdAsync(id);
			if (message != null && !message.IsRead)
			{
				message.IsRead = true;
				_repository.Update(message);
			}
		}

		public async Task SendMessageAsync(ContactMessage message)
		{
			await _repository.AddAsync(message);
		}
	}
}
