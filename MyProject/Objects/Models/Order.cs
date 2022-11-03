namespace MyProject.Objects.Models
{
    public class Order
    {
         public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Products Products { get; set; }
        public virtual User User { get; set; }
        public int TotalCost
        {
            get { return TotalCost; }
            set
            {
                TotalCost += value;
            }
        }

       
    }
}
