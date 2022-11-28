using System;
using System.Collections.Generic;

#nullable disable

namespace Lab_SP_2022.Models
{
    public partial class TestTable
    {
        public int Id { get; set; }
        public int? IntColumn { get; set; }
        public string VarcharColumn { get; set; }
    }
}
