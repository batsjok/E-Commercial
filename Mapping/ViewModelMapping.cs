using AutoMapper;
using WebApp.web.Models;
using WebApp.web.ViewModel;

namespace WebApp.web.Mapping
{
    public class ViewModelMapping:Profile
	{
       public ViewModelMapping()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Visitor, VisitorViewModel>().ReverseMap();
        }
    }
}

