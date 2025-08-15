namespace TaskApi.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsCompleted { get; set; } = false; // Por defecto false
    }
}

