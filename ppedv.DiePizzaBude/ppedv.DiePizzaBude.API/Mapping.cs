namespace ppedv.DiePizzaBude.API
{
    using AutoMapper;
    using ppedv.DiePizzaBude.API.Model;
    using ppedv.DiePizzaBude.Model.DomainModel;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping from Pizza to PizzaDTO
            CreateMap<Pizza, PizzaDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => (int)src.Size));

            // Mapping from PizzaDTO to Pizza
            CreateMap<PizzaDTO, Pizza>()
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => (PizzaSize)src.Size))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s=>s.Name))  // If Name should not be mapped
                .ForMember(dest => dest.Toppings, opt => opt.Ignore()); // If Toppings should not be mapped
            // etc. for other properties
    }
    }

}
