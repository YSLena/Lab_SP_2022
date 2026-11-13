using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab_SP_2022.Models
{
    /* 
    * Клас для повернення даних із функції Inline_F01 
    * Повинен мати такі ж властивості, як і вихідний набір функції 
    */

    public class Inline_F01_Res
    {
        public string SURNAME { get; set; }
        public string NAME { get; set; }
        public string PATRONYMIC { get; set; }
        public string GROUP_NUMBER { get; set; }
    }
}
