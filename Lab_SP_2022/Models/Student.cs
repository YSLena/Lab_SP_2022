using System;
using System.Collections.Generic;

#nullable disable

namespace Lab_SP_2022.Models
{
    public partial class Student
    {
        public Student()
        {
            Groups = new HashSet<Group>();
        }

        public int StudentId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int? GroupId { get; set; }
        public int? Absences { get; set; }
        public int? UnreasonableAbsences { get; set; }
        public int? UnreadyLabs { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
