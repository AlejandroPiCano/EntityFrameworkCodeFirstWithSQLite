namespace TodoItems.Infrastructure.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }

        public override string ToString()
        {
            return $"Description: {Description}";
        }
    }
}