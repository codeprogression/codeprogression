using AutoMapper;
using NETDUGSample.DTO;
using NETDUGSample.Entity;

namespace NETDUGSample.Mapping
{
    public class AttendeeProfile : Profile
    {
        protected override string ProfileName
        {
            get { return "AttendeeProfile"; }
        }

        protected override void Configure()
        {

            Mapper.CreateMap<Attendee, AttendeeDto>()
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.FirstName + " " + s.LastName));
            Mapper.CreateMap<Attendee, AttendeeDetailDto>();
            Attendee attendee=null;
            Mapper.CreateMap<int, AttendeeDetailDto>()
                .BeforeMap((s, d) => attendee = new AttendeeRepository().GetById(s))
                .ForMember(d => d.Id, x => x.MapFrom(s => attendee.Id))
                .ForMember(d => d.FirstName, x => x.MapFrom(s => attendee.FirstName))
                .ForMember(d => d.LastName, x => x.MapFrom(s => attendee.LastName))
                .ForMember(d => d.Status, x => x.MapFrom(s => attendee.Status))
                .ForMember(d => d.EmailAddress, x => x.MapFrom(s => attendee.EmailAddress))
                .ForMember(d => d.WebPage, x => x.MapFrom(s => attendee.Webpage??"No web page specified"));
        }
    }
}