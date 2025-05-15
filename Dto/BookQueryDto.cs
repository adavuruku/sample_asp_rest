namespace BookStoreApi.Dto
{
    public class BookQueryDto
    {
        public string? Author { get; set; }
        public string? Title { get; set; }
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
