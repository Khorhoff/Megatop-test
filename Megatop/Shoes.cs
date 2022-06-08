namespace Megatop
{
    public class Shoes
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }

        public Shoes(string Name, string Description, int Id)
        {
            this.Name = Name;
            this.Description = Description;
            this.Id = Id;
        }
    }
}
