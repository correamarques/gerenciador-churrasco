using System.Collections.Generic;

namespace ChurrascoManager.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}