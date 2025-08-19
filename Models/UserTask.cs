namespace Goal_Mate.Models
{
    public enum TaskPriority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
    public class UserTask
    {
        public int TaskId {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public TaskPriority Priority {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate {  get; set; } 
    }
}
