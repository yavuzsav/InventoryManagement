using AutoMapper;
using Domain;

namespace Application.StockMovements
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StockMovement, StockMovementDto>()
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name));
        }
    }
}