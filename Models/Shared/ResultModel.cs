namespace EntityFrameworkLesson.Models.Shared
{
    public class ResultModel<T>
    {
        public bool IsSuccess { get; set; } = false;
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
