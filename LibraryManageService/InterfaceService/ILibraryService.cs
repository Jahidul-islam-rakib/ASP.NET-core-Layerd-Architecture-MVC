using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManageModel.Entities;

namespace LibraryManageService.InterfaceService
{
    public interface ILibraryService
    {
        Task<IEnumerable<Book>> GetAllBookAsync();
        Task<Book> GetByIdAsync(int id);
        Task AddAsync(Book entity);
        Task UpdateAsync(Book entity);
        Task DeleteAsync(int id);

    }
}
