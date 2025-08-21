namespace Goal_Mate.Models
{
    public class Subtask
    {
        public int SubtaskId {  get; set; }
        public string Title { get; set; }
        public int UserTaskId {  get; set; }
        public virtual UserTask UserTask { get; set; }
    }
}
