using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace Lab_SP_2022.Models
{
        /* TODO 1.1aaa: Довизначення контексту 
        * Включаємо нові класи в контекст 
        * Клас контексту визначено як partial 
        * Це дозволяє нам доповнювати його, не змінюючи автозгенерований код 
        * (інакше при перебудові моделі можна змінити свої зміни) 
        */

    public partial class FacultyContext : DbContext
    {
        // Наборы данных для возврата из запросов и табличных функций
        public virtual DbSet<Example12_Res> Example12_Res { get; set; }
        public virtual DbSet<Inline_F01_Res> Inline_F01_Res { get; set; }

        public virtual DbSet<IntScalar> IntScalar { get; set; }

        /* TODO 1.1bb. Створення методів для мапінгу функцій
         * Створюється метод-обгортка, до якого прив'язується визов SQL-функції
         * В коді програми цей метод визиваєьться як звичайно
         * Після створення методу-обгортки його необхіжно прив'язати до функції в БД
         * в методі OnModelCreatingPartial 
         * 
         */

        // методи для мапінга функцій
        public IQueryable<Inline_F01_Res> Inline_F01_Wrap(string GrNum, int Absc)
            => throw new NotSupportedException();

        // мапінг
        public IQueryable<Inline_F01_Res> Inline_F01_Map(string GrNum, int Absc)
            => FromExpression<Inline_F01_Res>(() => Inline_F01_Wrap(GrNum, Absc));

        / * TODO ??? 
        * х.з., чого прив'язка методу до скалярної функції не працює 
        * є відчуття, що я якоїсь фігні не розумію 
        */
        public int Scalar_Function_N0100(string GrNum, int Absc)
            => throw new NotSupportedException();

        //public int Scalar_N0100_Map(string GrNum, int Absc)
        //    => FromExpression<int>(() => Scalar_N0100_Wrap(GrNum, Absc));


        /* 
        * Використовуючи Fluent API, визначаємо властивості набору даних 
        * Зокрема вказуємо, що набори, що повертаються табличними функціями, 
        * не мають ключового поля 
        */
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Example12_Res>().HasNoKey();
            modelBuilder.Entity<Inline_F01_Res>().HasNoKey();
            modelBuilder.Entity<IntScalar>().HasNoKey();

            /* TODO 1.1bbb. Настройка мапінгу SQL-функцій на методи програми
             */


            modelBuilder.HasDbFunction(typeof(FacultyContext)
                .GetMethod(nameof(Inline_F01_Wrap)))
                .HasName("Inline_Function_N01");

            //modelBuilder.HasDbFunction(typeof(FacultyContext).GetMethod(nameof(Scalar_Function_N0100), new[] { typeof(int) }))
            //    .HasName("Scalar_Function_N0100");

            // Повертайтесь к задаче TODO 1.1b
        }
    }
}

