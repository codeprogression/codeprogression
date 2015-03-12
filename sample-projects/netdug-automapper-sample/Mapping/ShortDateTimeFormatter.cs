using System;

namespace NETDUGSample.Mapping
{
    public class ShortDateTimeFormatter : BaseFormatter<DateTime>
    {
        protected override string FormatValueCore(DateTime value)
        {
            return value.ToString("g");
        }
    }
}