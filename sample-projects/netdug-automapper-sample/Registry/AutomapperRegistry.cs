using AutoMapper;
using NETDUGSample.Mapping;

namespace NETDUGSample.Registry
{
    public class AutomapperRegistry
    {
        public static void Configure()
        {
            Mapper.Reset();
            Mapper.Initialize(x =>
            {
                x.AddProfile<MeetingProfile>();
                x.AddProfile<AttendeeProfile>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}