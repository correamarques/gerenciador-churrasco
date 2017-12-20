namespace ChurrascoManager.Models
{
    public class Enrollment
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int PersonID { get; set; }
        public bool Paid { get; set; }
        public bool Drink { get; set; }
        public decimal Amount { get; set; }

        public virtual Person Person { get; set; }
        public virtual Event Event { get; set; }
    }
}