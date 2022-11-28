using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace Lab_SP_2022.Models
{
    /* TODO 1.1aaa: Доопределение контекста
     * Включаем новые классы в контекст 
     * Класс контекста определён как partial
     * Это позволяет нам дополнять его, не изменяя автосгенерированный код
     * (иначе при перестроении модели можно потрять свои изменения)
     */

    public partial class FacultyContext : DbContext
    {
        // Наборы данных для возврата из запросов и табличных функций
        public virtual DbSet<Example12_Res> Example12_Res { get; set; }
        public virtual DbSet<Inline_F01_Res> Inline_F01_Res { get; set; }

        public virtual DbSet<IntScalar> IntScalar { get; set; }

        /* TODO 1.1bb. Створення метдів для мапінгу функцій
         * Створюється метод-обгортка, до якого прив'язується визов SQL-функції
         * В коді програми цей метод визиваєьться як звичайно
         * Після створення методу-обгортки його необхіжно прив'язати до функції в БД
         * в методі OnModelCreatingPartial 
         * 
         */

        // методы для маппинга функций
        public IQueryable<Inline_F01_Res> Inline_F01_Wrap(string GrNum, int Absc)
            => throw new NotSupportedException();

        // маппинг
        public IQueryable<Inline_F01_Res> Inline_F01_Map(string GrNum, int Absc)
            => FromExpression<Inline_F01_Res>(() => Inline_F01_Wrap(GrNum, Absc));

        /* TODO ???
         * х.з., чего привязка метода к скалярной функции не работает
         * есть ощущуение, что я какой-то фигни не понимаю
         */
        public int Scalar_Function_N0100(string GrNum, int Absc)
            => throw new NotSupportedException();

        //public int Scalar_N0100_Map(string GrNum, int Absc)
        //    => FromExpression<int>(() => Scalar_N0100_Wrap(GrNum, Absc));


        /* 
         * Используя Fluent API, определяем свойства набора данных
         * В частности указываем, что наборы, возвращаемые табличными функциями,
         * не имеют ключевого поля
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

            // Возвращайтесь к задаче TODO 1.1b
        }
    }
}

