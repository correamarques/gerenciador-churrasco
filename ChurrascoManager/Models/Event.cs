using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChurrascoManager.Models
{
    public class Event
    {
        public int ID { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Display(Name = "Observação"), DataType(DataType.MultilineText)]
        public string Observation { get; set; }
        [Display(Name = "Valor gasto")]
        public decimal Amount { get; set; }
        [Display(Name = "Data"), DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}