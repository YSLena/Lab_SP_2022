using System;
using System.Collections.Generic;

#nullable disable

namespace Lab_SP_2022.Models
{
    public partial class Chair
    {
        public Chair()
        {
            Groups = new HashSet<Group>();
            Tutors = new HashSet<Tutor>();
        }

        public int ChairId { get; set; }
        public string ChairNumber { get; set; }
        public int? ChairHeadId { get; set; }
        public int? DeputyDeanId { get; set; }

        public virtual Tutor ChairHead { get; set; }
        public virtual Tutor DeputyDean { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Tutor> Tutors { get; set; }
    }
}
