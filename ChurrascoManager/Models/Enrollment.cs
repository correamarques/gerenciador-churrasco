using System.ComponentModel.DataAnnotations;

namespace ChurrascoManager.Models
{
    public class Enrollment
    {
        public int ID { get; set; }
        [Display(Name = "Evento")]
        public int EventID { get; set; }
        [Display(Name = "Nome")]
        public int PersonID { get; set; }
        [Display(Name = "Pago")]
        public bool Paid { get; set; }
        [Display(Name = "Vai beber?")]
        public bool Drink { get; set; }
        [Display(Name = "Valor pago")]
        public decimal Amount { get; set; }
        [Display(Name = "Observação")]
        public string Observation { get; set; }

        public virtual Person Person { get; set; }
        public virtual Event Event { get; set; }
    }
}