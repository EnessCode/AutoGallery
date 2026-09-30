using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class AdminUser : BaseEntity
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }
	}
}
