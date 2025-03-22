namespace Qubik.Hackathon.API.DTOs
{
    public class Pagination
    {
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }
    }

}
