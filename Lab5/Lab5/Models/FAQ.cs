namespace Lab5.Models
{
    public class FAQ
    {
        public int Id { get; set; } 

        public string Question { get; set; }

        public string Answer { get; set; }

        public string TopicID { get; set; }

        public Topic Topic { get; set; }

        public string CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
