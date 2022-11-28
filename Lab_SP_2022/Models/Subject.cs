using System;
using System.Collections.Generic;

#nullable disable

namespace Lab_SP_2022.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Curricula = new HashSet<Curriculum>();
        }

        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int? ChairId { get; set; }
        public string ChairExternal { get; set; }

        public virtual ICollection<Curriculum> Curricula { get; set; }
    }
}
