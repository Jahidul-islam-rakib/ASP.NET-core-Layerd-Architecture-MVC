using LibraryManageModel.Entities;
using LibraryManageRepository.DbConfigure;
using LibraryManageRepository.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManageRepository.Repository
{
	public class LibraryRepository : ILibraryRepository
	{
		private readonly LibraryDBContext _context;

		public LibraryRepository(LibraryDBContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Book>> GetAllBookAsync()
		{
			return await  _context.Books.ToListAsync();
		}

		public async Task<Book> GetByIdAsync(int id)
		{
			return await _context.Books.FindAsync(id);
		}

		public async Task AddAsync(Book entity)
		{
			_context.Books.Add(entity);
			await _context.SaveChangesAsync();

		}

		public async Task UpdateAsync(Book entity)
		{
			_context.Books.Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _context.Books.FindAsync(id);

			if (entity != null)
			{
				_context.Books.Remove(entity);
				await _context.SaveChangesAsync();
			}


		}
	}
}
