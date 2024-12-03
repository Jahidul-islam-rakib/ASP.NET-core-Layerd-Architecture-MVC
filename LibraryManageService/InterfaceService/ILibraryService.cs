using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManageModel.BusinessModel;
using LibraryManageModel.Entities;

namespace LibraryManageService.InterfaceService
{
    public interface ILibraryService
    {
        Task<IEnumerable<BookVM>> GetAllBookAsync();
        Task<BookVM> GetByIdAsync(int id);
        Task AddAsync(BookVM entity);
        Task UpdateAsync(BookVM entity);
        Task DeleteAsync(int id);

    }
}
