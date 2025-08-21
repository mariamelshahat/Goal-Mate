namespace Goal_Mate.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public virtual List<UserTask> Tasks { get; set; } = new List<UserTask> ();
    }
}
