namespace AdventureMVC.Data.IBatis
{
    public class PagingParameter
    {
        public PagingParameter(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            Page = pageNumber;
        }
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}