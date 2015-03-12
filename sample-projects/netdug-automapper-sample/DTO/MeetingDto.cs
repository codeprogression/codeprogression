namespace NETDUGSample.DTO
{
    public class MeetingDto
    {
        public string Title { get; set; }
        public string Begins { get; set; }
        public int LengthInMinutes { get; set; }
        public int AttendeesCount { get; set; }
        public int ConfirmedCount { get; set; }
        public int RejectedCount{ get; set; }
        public int PendingCount { get; set; }
        public int HasWebPageCount;
    }
}