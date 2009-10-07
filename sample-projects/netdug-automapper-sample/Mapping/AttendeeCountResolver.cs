using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using NETDUGSample.Entity;

namespace NETDUGSample.Mapping
{
    public class AttendeeCountResolver : IValueResolver
    {
        readonly Expression<Func<Attendee, bool>> _func;

        public AttendeeCountResolver(Expression<Func<Attendee,bool>> func)
        {
            _func = func;
        }

        public ResolutionResult Resolve(ResolutionResult source)
        {
            var attendees = (IList<Attendee>)source.Value;
            var count = attendees.Count(_func.Compile());
            return new ResolutionResult(count);
        }
    }
}