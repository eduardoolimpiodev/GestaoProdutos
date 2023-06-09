namespace GP.WebApi.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get{ return pageSize; }
            set{ pageSize = (value > MaxPageSize) ? MaxPageSize : value; } 
        }

        public string? Nome { get; set; } = null;

        public string Marca { get; set; } = string.Empty;

        public int? Situacao { get; set; } = null;

    }
}