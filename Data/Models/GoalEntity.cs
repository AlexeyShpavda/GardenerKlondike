namespace Data.Models
{
    public class GoalEntity
    {
        public string Title { get; set; }

        public string Note { get; set; }

        public bool IsCompleted { get; set; }

        public string UserEmail { get; set; }
    }
}