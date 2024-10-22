using LibraryManageModel.Entities;
using LibraryManageRepository.InterfaceRepository;
using LibraryManageRepository.Repository;
using LibraryManageService.InterfaceService;
using LibraryManageService.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace LibraryManage.Controllers
{
    public class BookController : Controller
    {
        private readonly ILibraryRepository _IBook;
        private readonly ILibraryService _LibraryService;

        public BookController(ILibraryService LibraryService)
        {
            _LibraryService = LibraryService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _LibraryService.GetAllBookAsync();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> Create(Book book)
		{
			 await _LibraryService.AddAsync(book);

			return RedirectToAction("Index");
		}

        public async Task<IActionResult> Delete(int id)
        {
            await _LibraryService.DeleteAsync(id);

             return RedirectToAction("Index");

        }

        public async Task<IActionResult> Update(int id)
        {
            var book = await _LibraryService.GetByIdAsync(id);
            return View(book);
		}
		[HttpPost]
        public async Task<IActionResult> Update(Book book)
        {
            if(book.Id > 0 )
            {
                await _LibraryService.UpdateAsync(book);
            }

            return RedirectToAction("Index");
        }

        public async Task <IActionResult> Details(int id)
        {
            var book = await _LibraryService.GetByIdAsync(id);
            return View(book);
        }


    }
}
