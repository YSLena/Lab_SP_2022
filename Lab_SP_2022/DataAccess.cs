using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using System.Windows.Forms;

namespace Lab_SP_2022
{
    class DataAccess
    {
        /* TODO 0 : Цели и задачи
         * Задача лабораторной - изучение средств технологии Entity Framework Core 
         * для работы с SQL-запросами, в т.ч. 
         * для использования функционала БД (хранимых процедур и пользовательских функций).
         * Документация:
         * https://docs.microsoft.com/ru-ru/ef/core/querying/raw-sql#limitations
         */

        /* TODO 0.1: Подготовка к работе
         * Должны быть установлены NuGet пакеты:
         * - Microsoft.EntityFrameworkCore.SqlServer,
         * - Microsoft.EntityFrameworkCore.Tools.
         * Это можно сделать через менеджер пакетов (Project \ Manage NuGet Packages ...).
         * 
         * Или через консоль диспетчер пакетов (Tools \ NuGet Package Manager \ Package Manager Console), 
         * выполнив команды:
         * Install-Package Microsoft.EntityFrameworkCore.SqlServer -version 5.0.17
         * Install-Package Microsoft.EntityFrameworkCore.Tools -version 5.0.17
         * 
         * Версия 5.0.17 выбрана для совместимости с .NET Core 3.1, 
         * т.к. не все ещё установили VS 2022, а на VS 2019 новейшие версии не пойдут 
         * 
         * Модель данных создана командой:
         * Scaffold-DbContext "Data Source=magister-v;Initial Catalog=Faculty_UA_22;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -Context FacultyContext -OutputDir Models -Tables STUDENTS, GROUPS, SUBJECTS, TUTORS, CHAIRS, CURRICULUM, Test_Table
         * Классы модели данных находятся в папке Models
         */

        /* TODO 0.2: З'єднання з БД
         * Замініть строку з'єднання в контексті даних (файл Model\FacultyContext.cs )
         * 
         * Необходимо создать модель сущностых классов, используя подход DataBase First,
         * т.е. сгенерировать модель на основе существующей БД.
         * Для этого в окне диспетчера пакетов (Package Manager Console) выполните команду,
         * указав в ней путь к БД Faculty_UA_22:
         * 
         * 
         * Команда не отработает, если есть ошибки компиляции
         * 
         * Документация:
         * https://docs.microsoft.com/ru-ru/ef/core/managing-schemas/scaffolding?tabs=vs
         */


        public Form1 form1;

        Models.FacultyContext context = new Models.FacultyContext();

        /* TODO 1.1a: Примеры выполнения SQL-запросов
         */

        /* Пример 1.0
          * Простой запрос с возвратом объектов сущностного класса Students
          * Раскомментируйте строку ниже, запустите программу и нажмите на форме первую кнопку "Вызвать!"
          */
        //form1.dataGridView11.DataSource = context.Students.FromSqlRaw("SELECT * FROM STUDENTS").ToList();

        /* Пример 1.1
         * Запрос с возвратом не-сущностных объектов
         * Прежде чем выполнять запрос, найдите в списке задач (View \ Task List)
         * задачи TODO 1.1a и 1.1b (они в других файлах)
         */

        /* Пример 1.2
         * Вызов функции Inline_F01
         * Откройте эту функцию в БД или в обозревателе серверов
         * Для этого раскройте БД Faculty_UA_22 и найдите в ней Functions или Programmability \ Functions
         * Изучите входные параметры и структуру выходного набора
         * Для возврата данных создан класс Lab_sp.Models.Inline_F01_Res, 
         * по аналогии с тем, как это сделано в предыдущем примере
         * Значения param1 и param1 устаналиваются на форме Form1
         */

        // Передача параметров путём форматирования строки
        //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlRaw("SELECT * FROM dbo.Inline_Function_N01 ({0}, {1})", param1, param2).ToList();

        // Передача параметров через интерполированную строку $""
        //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlInterpolated($"SELECT * FROM dbo.Inline_Function_N01 ({param1}, {param2})").ToList();

        /* Пример 1.3
         * Создание параметризованного запроса для вызова функции
         * Параметры @group и @absences тспользуются для передачи значений param1 и param1 
         * Обратите внимание на преобразование типа параметра param2
         */

        //var par_group = new Microsoft.Data.SqlClient.SqlParameter("@group", param1);
        //var par_absences = new Microsoft.Data.SqlClient.SqlParameter("@absences", int.Parse(param2));
        // интерполяция
        //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlInterpolated($"SELECT * FROM dbo.Inline_Function_N01 ({par_group}, {par_absences})").ToList();
        // или форматирование
        //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlRaw($"SELECT * FROM dbo.Inline_Function_N01 (@group, @absences)", par_group, par_absences).ToList();


        /* Больше примеров:
         * https://www.learnentityframeworkcore.com/raw-sql
         */

        public void Task11a_Example(string param1, string param2)
        {
            // создание параметров (см. Пример 1.3)
            var par_group = new Microsoft.Data.SqlClient.SqlParameter("@group", param1);
            var par_absences = new Microsoft.Data.SqlClient.SqlParameter("@absences", int.Parse(param2));
            // вызов функции с параметрами
            form1.dataGridView11.DataSource = context.Inline_F01_Res.
                FromSqlInterpolated($"SELECT * FROM dbo.Inline_Function_N01 ({par_group}, {par_absences})").ToList();

            /* Другие примеры выполнения SQL-запросов
             * Все примеры работоспособны, можете выполнять их по очереди
             * Раскомментируйте нужную строку, запустите программу и нажмите на форме первую кнопку "Вызвать!"
             * Описание примеров см. в комментарии выше
             */

            /* Пример 1.0 */
            //form1.dataGridView11.DataSource = context.Students.FromSqlRaw("SELECT * FROM STUDENTS").ToList();

            /* Пример 1.1 */
            //form1.dataGridView11.DataSource = context.Example12_Res.FromSqlRaw("SELECT Name, Surname FROM STUDENTS").ToList();

            /* Пример 1.2 */
            //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlRaw("SELECT * FROM dbo.Inline_Function_N01 ({0}, {1})", param1, param2).ToList();
            // или
            //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlInterpolated($"SELECT * FROM dbo.Inline_Function_N01 ({param1}, {param2})").ToList();
        }



        /* TODO 1.1b: Приклад визову збереженої користувацької функції шляхом прив'язки методу
         * Створення методів та прив'язку див. в TODO 1.1bb, TODO 1.1bbb
         * в файлі FacultyContext_Extend.cs
         * В контексті створюється метод, визов якого проецюється на SQL-функцію в БД
         * 
         * Документація та приклади:
         * https://learn.microsoft.com/ru-ru/ef/core/querying/user-defined-function-mapping
         * https://www.allhandsontech.com/data-professional/entityframework/entity-framework-core-advanced-mapping/
         * https://metanit.com/sharp/entityframeworkcore/6.2.php
         */

        public void Task11b_Example(string param1, string param2)
        {
            form1.dataGridView11.DataSource = context.Inline_F01_Map(param1, Int32.Parse(param2)).ToList();
        }

        /* TODO 1.2
         * Создание и вызов собственной пользовательской функции
         * В БД создайте собственную пользовательскую функцию на языке Transact-SQL 
         * в соответсвии с вариантом задания
         * Дополнительные сведения и примеры функций Transact-SQL см. в библиотеке MSDN:
         * https://msdn.microsoft.com/ru-ru/library/ms186755.aspx
         * 
         * Для создания функции найдите список функций БД (см. предыдущую задачу), щёлкните правой кнопкой на списке Functions
         * и выберите команду Add new \ Inline Function
         * В открывшемся окне отредактируйте код SQL-запроса CREATE FUNCTION
         * 
         * В методе Task12() запрограммируйте вызов этой функции
         * и привязку возвращённых ею данных к компоненту form1.dataGridView11
         * Не забудьте создать класс для возврата результатов и включить его в контекст (см. примеры в п. 1.1a)
         * Если второй параметр не нужен - забейте на него (он нужен для привязки к форме, т.к. там два текстбокса)
         */

        public void Task12(string param1, string param2)
        {
            form1.dataGridView11.DataSource = null;
        }

        /* TODO 1.3
         * Создание и вызов собственной табличной пользовательской функции
         * В БД создайте собственную пользовательскую функцию на языке Transact-SQL 
         * в соответсвии с вариантом задания
         * Не забудьте описать класс для структуры выходной таблицы
         * В качестве примера можно посмотреть в БД функцию Table_Function_N0100
         * В методе Task13() запрограммируйте вызов этой функции
         * и привязку возвращённых ею данных к компоненту form1.dataGridView11
         */
        public void Task13(string param1, string param2)
        {
            form1.dataGridView11.DataSource = null; 
        }


        /* TODO 2.1: Приклад визову збереженої скалярної функції
         * Необхідно створити клас, за допомогою якого повернеться результат фкнуції,
         * див. коментар TODO 2.11 в файлі IntScalar.cs
         * Сам визов нагадує визов табличної функції, але, 
         * оскільки повернеться лише одно число, застосовується метод FirstOrDefault().
         * За допомогою оператора ?? перевіряється, що результат не є пустим.
         * Якщо треба, NULL замінюється на 0.
         */

        public void Task21(string param1, string param2)
        {
            var par_group = new Microsoft.Data.SqlClient.SqlParameter("@group", param1);
            var par_absences = new Microsoft.Data.SqlClient.SqlParameter("@absences", int.Parse(param2));

            form1.label21res.Text = (context.IntScalar
                .FromSqlInterpolated($"SELECT dbo.Scalar_Function_N0100({par_group}, {par_absences}) AS Result")
                .FirstOrDefault()?.Result ?? 0).ToString();

            // привязка метода почему-то не работает :(
            //form1.label21res.Text = context.Scalar_Function_N0100(param1, Int32.Parse(param2)).ToString(); 
        }


        /* TODO 2.2: Створеня власної скалярної функції
         * Створіть в БД скалярну функцію за варіантом завдання.
         * В якаості прикладу розглянте функцію Scalar_Function_N0100, яка збережена в БД
         * В методі Task22() напішіть запит для визову вашої функції та отримання результату,
         * який буде виведено на формі в елементі label22res
         * Метод Task22() отримує два параметри від форми, якщо другий параметр не потрібен - ігноруйте його
         */

        public void Task22(string param1, string param2)
        {

            form1.label22res.Text = "?";
        }



        /* TODO 3.1
         * Пример вызова хранимой процедуры StoredProc_N0100
         * Обратите внимание на получение выходного параметра,
         * а также обработку исключений
         * 
         * Для просмотра результатов на форме перейдите на вкладку Вызов хранимых процедур 
         * и нажмите первую кнопку Вызвать!
         */

        public int OutValue31 = -1;

        public void Task31(string param1, string param2, string param3)
        {
            try
            {

                var par_output = new Microsoft.Data.SqlClient.SqlParameter("@outparam", System.Data.SqlDbType.Int);
                par_output.Direction = System.Data.ParameterDirection.Output;

                // интерполяция строк
                context.Database.ExecuteSqlInterpolated($"EXEC StoredProc_N0100 {param1}, {param2}, {param3}, {par_output} OUT");

                //обновление данных на форме
                form1.Test_dataGridView.DataSource = context.TestTables.ToList();
                OutValue31 = (int)par_output.Value;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message+"\n\n"+ (e.InnerException != null ? e.InnerException.Message : ""));
            }
        }

        /* TODO 3.2
         * Создание хранимой процедуры в соответсвии с вариантом задания.
         * В БД создайте собственную хранимую процедуру на языке Transact-SQL 
         * в соответсвии с вариантом задания
         * Дополнительные сведения и примеры создания хранимых процедур Transact-SQL 
         * см. в библиотеке MSDN:
         * https://msdn.microsoft.com/ru-ru/library/ms187926.aspx
         * 
         * В методе Task32() запрограммируйте вызов этой хранимой процедуры
         * и обновление данных из таблицы Test_Table в компоненте form1.Test_dataGridView
         * Не забудьте получить выходной параметр 
         * Значение выходного параметра поместите в переменную OutValue22
         * Реализуйте обработку исключений
         */

        public int OutValue32 = -1;

        public void Task32(string param1, string param2)
        {
            form1.Test_dataGridView.DataSource = null;
        }

    }
}
