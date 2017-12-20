using System;
using System.Collections.Generic;

namespace ChurrascoManager.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}