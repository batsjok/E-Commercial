using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.web.Models;
using WebApp.web.Models.ViewModel;

namespace WebApp.web.Views.Shared.ViewComponent
{
    public class ProductListViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync( int type = 1)
        {
            var viewmodels = _context.ProductTBL.Select(x => new ProductListComponentViewModel
            {
                Name = x.Name,
                Describtion = x.Describtion
            }).ToList();
            if(type ==1)
            {
                return View("ProductList",viewmodels);
            }
            else
            {
                return View("Type2", viewmodels);
            }
            
        }

        private IViewComponentResult Views(List<ProductListComponentViewModel> viewmodels)
        {
            return View("ProductList", viewmodels);
        }
    }
}
