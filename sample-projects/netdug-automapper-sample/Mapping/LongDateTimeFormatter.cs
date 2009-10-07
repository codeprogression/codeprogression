using System;

namespace NETDUGSample.Mapping
{
    public class LongDateTimeFormatter : BaseFormatter<DateTime>
    {
        protected override string FormatValueCore(DateTime value)
        {
            return value.ToString("F");
        }
    }
}