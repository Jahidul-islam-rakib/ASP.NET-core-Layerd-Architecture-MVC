using LibraryManageService.InterfaceService;
using LibraryManageRepository.DbConfigure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManageRepository.InterfaceRepository;
using LibraryManageModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManageService.Service
{
    public class LibraryService : ILibraryService
    {
        private ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBookAsync()
        {
            return await _libraryRepository.GetAllBookAsync();
        }


        public async Task<Book> GetByIdAsync(int id)
        {
            return await _libraryRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Book entity)
        {
             await _libraryRepository.AddAsync(entity);

        }

        public async Task UpdateAsync(Book entity)
        {
			await _libraryRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _libraryRepository.DeleteAsync(id);
        }
    }
}
