using APIBookCatalog.Models;
using AutoMapper;

namespace APIBookCatalog.DTOs.Mapping
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
