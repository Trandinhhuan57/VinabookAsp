using AutoMapper;
using DataAccessLayer.Entities;
using WebApplication.Models;

namespace WebApplication.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Flower, FlowerVM>().ReverseMap();
        }
    }
}