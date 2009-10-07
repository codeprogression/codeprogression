using System;
using AutoMapper;
using NETDUGSample.Entity;

namespace NETDUGSample.Mapping
{
    public class TimeSpanResolver : IValueResolver
    {
        public ResolutionResult Resolve(ResolutionResult source)
        {
            var dates = (Tuple<DateTime, DateTime>)source.Value;
            return new ResolutionResult(Math.Abs(dates.Second.Subtract(dates.First).TotalMinutes));
        }
    }
}