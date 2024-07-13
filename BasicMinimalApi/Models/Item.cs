namespace BasicMinimalApi.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Type { get; set; } = string.Empty;

        public int UserId { get; set; }
    }
}
