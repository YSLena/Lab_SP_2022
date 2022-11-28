using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab_SP_2022.Models
{
    /*
     * Класс для возврата данных из функции Inline_F01
     * Должен иметь такие же свойства, что и выходной набор функции
     */

    public class Inline_F01_Res
    {
        public string SURNAME { get; set; }
        public string NAME { get; set; }
        public string PATRONYMIC { get; set; }
        public string GROUP_NUMBER { get; set; }
    }
}
