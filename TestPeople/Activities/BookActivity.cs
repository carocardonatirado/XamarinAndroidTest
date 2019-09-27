using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Lilarcor.Cheeseknife;
using TestPeople.Adapter;
using TestPeople.Logic.Business.Dtos;
using TestPeople.Logic.Business.Managers;
using TestPeople.Logic.Repositories.Remote;
using TestPeople.Utilities;

namespace TestPeople.Activities
{
    [Activity(Label = "BookActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class BookActivity : BaseActivity
    {

        private BookAdapter _bookAdapter;
        private BookManager _bookModel;
        private IList<Book> books;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_book);
            Cheeseknife.Inject(this);
            _bookModel = new BookManager(new BookService(DeviceManager.Instance));

            this.RunOnUiThread(async () =>
            {
                await GetBookAsync();
            });
        }

        public async Task GetBookAsync()
        {
            try
            {
                BookResponse _booksResponse = await _bookModel.GetBooks();

                if (_booksResponse != null && _booksResponse.Books != null && _booksResponse.Books.Any())
                {
                    books = _booksResponse.Books;
                    DrawBooks();
                }
            }
            catch (Exception exeption)
            {
                Console.Write($"GetBookAsync: {exeption}");
            }
        }

        private void DrawBooks()
        {
          //  throw new NotImplementedException();
        }
    }
}
