using LibraryManageModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageRepository.InterfaceRepository
{
	public interface ILibraryRepository
	{
		Task<IEnumerable<Book>> GetAllBookAsync();
		Task<Book> GetByIdAsync(int id);
		Task AddAsync(Book entity);
		Task UpdateAsync(Book entity);
		Task DeleteAsync(int id);

	}
}
