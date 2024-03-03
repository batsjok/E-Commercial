using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp.web.Models;

namespace WebApp.Views.Shared.ViewComponents
{
    public class VisitorViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VisitorViewComponent(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var visitors = _context.VisitorsTBL.ToList();

            var visitorViewModels = _mapper.Map<List<VisitorViewModel>>(visitors);
            ViewBag.visitorViewModels = visitorViewModels;

            return View();
        }
    }
}
