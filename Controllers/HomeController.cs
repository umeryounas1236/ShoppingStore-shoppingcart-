using Microsoft.AspNetCore.Mvc;
using Shopping_Store.Repo;
using Shopping_Store.ViewModels;
using System.Linq;

namespace Shopping_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository storeRepository;
        public int PageSize = 4;

        public HomeController(IStoreRepository _storeRepository)
        {
            storeRepository = _storeRepository;
        }

        public IActionResult Index(string category,int productPage = 1)
        {
            ProductsListViewModel vm = new()
            {
                Products = storeRepository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new()
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                                storeRepository.Products.Count() :
                                storeRepository.Products.Where(e =>
                                e.Category == category).Count()

                },
                CurrentCategory = category
            };

            return View(vm);
        }
    }
}
