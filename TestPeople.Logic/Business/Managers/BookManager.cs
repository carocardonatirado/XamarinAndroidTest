using System.Threading.Tasks;
using TestPeople.Logic.Business.Contracts;
using TestPeople.Logic.Business.Dtos;

namespace TestPeople.Logic.Business.Managers
{
    public class BookManager
    {
        private IBookService _bookService { get; set; }

        public BookManager(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookResponse> GetBooks()
        {
            return await _bookService.GetBooks();
        }
    }
}
