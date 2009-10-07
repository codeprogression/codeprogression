using System;
using AutoMapper;
using NETDUGSample.DTO;
using NETDUGSample.Entity;

namespace NETDUGSample.Mapping
{
    public class MeetingProfile : Profile
    {
        protected override string ProfileName
        {
            get { return "MeetingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.AddFormatter<ShortDateTimeFormatter>();
//            Mapper.CreateMap<Meeting, MeetingDto>();
            Mapper.CreateMap<Meeting, MeetingDto>()
                .ForMember(d => d.LengthInMinutes,
                           o =>
                           o.ResolveUsing<TimeSpanResolver>().FromMember(
                               s => new Tuple<DateTime, DateTime>(s.End, s.Begins)))
                .ForMember(d => d.ConfirmedCount,
                           o => o.ResolveUsing<AttendeeCountResolver>().FromMember(s => s.Attendees).ConstructedBy(
                                    () => new AttendeeCountResolver(x => x.Status == AttendanceStatus.Confirmed)))
                .ForMember(d => d.RejectedCount,
                           o => o.ResolveUsing<AttendeeCountResolver>().FromMember(s => s.Attendees).ConstructedBy(
                                    () => new AttendeeCountResolver(x => x.Status == AttendanceStatus.Rejected)))
                .ForMember(d => d.PendingCount,
                           o => o.ResolveUsing<AttendeeCountResolver>().FromMember(s => s.Attendees).ConstructedBy(
                                    () => new AttendeeCountResolver(x => x.Status == AttendanceStatus.Pending)))
                .ForMember(d => d.HasWebPageCount,
                           o => o.ResolveUsing<AttendeeCountResolver>().FromMember(s => s.Attendees).ConstructedBy(
                                    () => new AttendeeCountResolver(x => x.Webpage.HasValue())));
        }
    }
}