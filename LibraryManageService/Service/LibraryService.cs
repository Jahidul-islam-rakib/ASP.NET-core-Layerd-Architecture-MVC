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
using AutoMapper;
using LibraryManageModel.BusinessModel;

namespace LibraryManageService.Service
{
    public class LibraryService : ILibraryService
    {
        private ILibraryRepository _libraryRepository;
		private readonly IMapper _mapper;

		public LibraryService(ILibraryRepository libraryRepository , IMapper mapper)
        {
            _libraryRepository = libraryRepository;
			_mapper = mapper;
		}

        public async Task<IEnumerable<BookVM>> GetAllBookAsync()
        {
			var obj = await _libraryRepository.GetAllBookAsync();
			var tran_VM = _mapper.Map<List<BookVM>>(obj);

			return tran_VM;
		}


        public async Task<BookVM> GetByIdAsync(int id)
        {
            var book = await _libraryRepository.GetByIdAsync(id);
            if (book == null)
                throw new Exception($"no book found");

            return _mapper.Map<BookVM>(book);

        }

        public async Task AddAsync(BookVM entity)
        {
			var NewBook = _mapper.Map<Book>(entity);
			await _libraryRepository.AddAsync(NewBook);

        }

        public async Task UpdateAsync(BookVM entity)
        {
			var con_VM = _mapper.Map<Book>(entity);
			await _libraryRepository.UpdateAsync(con_VM);
        }

        public async Task DeleteAsync(int id)
        {
            await _libraryRepository.DeleteAsync(id);
        }

		
	}
}
