using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NETDUGSample.DTO;
using NETDUGSample.Entity;
using NETDUGSample.Registry;

namespace NETDUGSample
{
    public class Program
    {
        static void Main()
        {
            Mapper.Reset();
            AutomapperRegistry.Configure();

            var repository = new AttendeeRepository();

            do
            {
                Console.Clear();
                var meeting = new Meeting
                {
                    Title = "Family Meeting",
                    Begins = DateTime.Now,
                    End = DateTime.Now.AddHours(1),
                    Attendees = repository.GetAll(),
                };

                var dto = Mapper.Map<Meeting, MeetingDto>(meeting);
                var attendeesDto = Mapper.Map<IList<Attendee>, IList<AttendeeDto>>(meeting.Attendees);

                Console.WriteLine("Meeting Title: " + dto.Title);
                Console.WriteLine(string.Format("Starts: {0} ({1} mins) ", dto.Begins, dto.LengthInMinutes));
                Console.WriteLine("Attendees with Web Pages: " + dto.HasWebPageCount);
                Console.WriteLine();
                Console.WriteLine("Attendees");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine(string.Format("Requested: {0}",dto.AttendeesCount));
                Console.WriteLine(string.Format("Confirmed: {0}", dto.ConfirmedCount));
                Console.WriteLine(string.Format("Rejected:  {0}", dto.RejectedCount));
                Console.WriteLine(string.Format("Pending:   {0}", dto.PendingCount));
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Attendeee Information");
                Console.WriteLine("------------------------------------------------------");
                foreach (var attendee in attendeesDto)
                    Console.WriteLine(string.Format("{0}) {1}", attendee.Id, attendee.FullName));
                Console.Write("Get detail information for:");

                var choice = Console.ReadKey().KeyChar;
                if (!new[] {'1', '2', '3', '4'}.Contains(choice))
                {
                    Console.Clear();
                    Console.WriteLine("You made a poor choice, Eddie!");
                    continue;
                }

                var chosenOne = Mapper.Map<int, AttendeeDetailDto>(Convert.ToInt32(choice.ToString()));

                Console.Clear();
                Console.WriteLine("First Name: " + chosenOne.FirstName);
                Console.WriteLine("Last Name: " + chosenOne.LastName);
                Console.WriteLine("Email Address: " + chosenOne.EmailAddress);
                Console.WriteLine("Web Page: " + chosenOne.WebPage);
                Console.WriteLine("Status: " + chosenOne.Status);

            } while (Console.ReadKey(true).KeyChar != 'x');
        }
    }
}