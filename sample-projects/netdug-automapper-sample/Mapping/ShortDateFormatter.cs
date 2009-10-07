using System;

namespace NETDUGSample.Mapping
{
    public class ShortDateFormatter : BaseFormatter<DateTime>
    {
        protected override string FormatValueCore(DateTime value)
        {
            return value.ToString("d");
        }
    }
}