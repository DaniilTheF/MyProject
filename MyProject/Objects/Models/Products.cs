namespace MyProject.Objects.Models
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string IMG { get; set; }

        public int Cost { get; set; }

        public bool OnMain { get; set; }

        public bool IsActive { get; set; }

        public virtual Types Types { get; set; }
    }
}
