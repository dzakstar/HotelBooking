using AutoMapper;
using DAL.Models;

namespace Models.Mappers
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingRequest, Booking>();
            CreateMap<Booking, BookingResponse>()
                .ForMember(dest =>
                        dest.BookingReference,
                    opt => opt.MapFrom(src => src.Id));
        }
    }
}
