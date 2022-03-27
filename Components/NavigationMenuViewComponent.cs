using Microsoft.AspNetCore.Mvc;
using Shopping_Store.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_Store.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IStoreRepository storeRepository;

        public NavigationMenuViewComponent(IStoreRepository _storeRepository)
        {
            storeRepository = _storeRepository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(storeRepository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
