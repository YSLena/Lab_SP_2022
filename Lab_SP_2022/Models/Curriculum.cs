using System;
using System.Collections.Generic;

#nullable disable

namespace Lab_SP_2022.Models
{
    public partial class Curriculum
    {
        public int CurriculumId { get; set; }
        public int? SubjectId { get; set; }
        public int? TutorId { get; set; }
        public int? GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
}
