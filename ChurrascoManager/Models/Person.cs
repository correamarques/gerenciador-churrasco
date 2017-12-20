using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChurrascoManager.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}