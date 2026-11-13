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
        /* TODO 0 : Цілі та завдання 
        * Завдання лабораторної – вивчення засобів технології Entity Framework Core 
        * до роботи з SQL-запросами, зокрема. 
        * для використання функціоналу БД (зберігаються процедури і функцій користувача). 
        * Документація: 
        * https://docs.microsoft.com/ef/core/querying/raw-sql#limitations 
        */
        
        /* TODO 0.1: Підготовка до роботи 
        * Повинні бути встановлені пакети NuGet: 
        * - Microsoft.EntityFrameworkCore.SqlServer, 
        * - Microsoft.EntityFrameworkCore.Tools. 
        * Це можна зробити через менеджер пакетів (Project\Manage NuGet Packages...). 
        * 
        * Або через консоль диспетчер пакетів (Tools \ NuGet Package Manager \ Package Manager Console), 
        * Виконавши команди: 
        * Install-Package Microsoft.EntityFrameworkCore.SqlServer -version 7.0.0
        * Install-Package Microsoft.EntityFrameworkCore.Tools -version 7.0.0 
        * 
        * Версія 7.0.0 вибрана для сумісності 
        * Якщо у вас встановлена більш нова версія .Net - обірайте відповідну версію
        * 
        * Модель даних створена командою: 
        * Scaffold-DbContext "Data Source = magister-v; Initial Catalog = Faculty_UA_22; Integrated Security = True" Microsoft.EntityFrameworkCore. CURRICULUM, Test_Table 
        * Класи моделі даних знаходяться у папці Models 
        * 
        * Документація: 
        * https://docs.microsoft.com/ef/core/managing-schemas/scaffolding?tabs=vs 
        */

        /* TODO 0.2: З'єднання з БД
         * Замініть строку з'єднання в контексті даних (файл Model\FacultyContext.cs )
         */


        public Form1 form1;

        Models.FacultyContext context = new Models.FacultyContext();

        /* TODO 1.1a: Приклади виконання SQL-запитів
         */

        /* Приклад 1.0 
        * Простий запит із поверненням об'єктів сутнісного класу Students 
        * Розкоментуйте рядок нижче, запустіть програму та натисніть на формі першу кнопку "Викликати!" 
        */
        //form1.dataGridView11.DataSource = context.Students.FromSqlRaw("SELECT * FROM STUDENTS").ToList();

        /* Пример 1.1
         * Запрос с возвратом не-сущностных объектов
         * Прежде чем выполнять запрос, найдите в списке задач (View \ Task List)
         * задачи TODO 1.1a и 1.1b (они в других файлах)
         */

        /* Приклад 1.2 
        * Виклик функції Inline_F01 
        * Відкрийте цю функцію в БД або в браузері серверів 
        * Для цього розкрийте БД Faculty_UA_22 і знайдіть у ній Functions або Programmability \ Functions 
        * Вивчіть вхідні параметри та структуру вихідного набору 
        * Для повернення даних створено клас Lab_sp.Models.Inline_F01_Res, 
        * за аналогією з тим, як це зроблено в попередньому прикладі 
        * Значення param1 та param1 встановлюються на формі Form1 
        */

        // Передача параметрів шляхом форматування рядка
        //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlRaw("SELECT * FROM dbo.Inline_Function_N01 ({0}, {1})", param1, param2).ToList();

        // Передача параметрів через інтерполований рядок $""
        //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlInterpolated($"SELECT * FROM dbo.Inline_Function_N01 ({param1}, {param2})").ToList();

        /* Приклад 1.3 
        * Створення параметризованого запиту для виклику функції 
        * Параметри @group і @absences використовуються для передачі значень param1 і param1 
        * Зверніть увагу на перетворення типу параметра param2 
        */
        
        //var par_group = new Microsoft.Data.SqlClient.SqlParameter("@group", param1);
        //var par_absences = new Microsoft.Data.SqlClient.SqlParameter("@absences", int.Parse(param2));
        // інтерполяциія
        //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlInterpolated($"SELECT * FROM dbo.Inline_Function_N01 ({par_group}, {par_absences})").ToList();
        // или форматування
        //form1.dataGridView11.DataSource = context.Inline_F01_Res.FromSqlRaw($"SELECT * FROM dbo.Inline_Function_N01 (@group, @absences)", par_group, par_absences).ToList();


        /* Більше прикладов:
         * https://www.learnentityframeworkcore.com/raw-sql
         */

        public void Task11a_Example(string param1, string param2)
        {
            // створення параметрів (див. приклад 1.3)
            var par_group = new Microsoft.Data.SqlClient.SqlParameter("@group", param1);
            var par_absences = new Microsoft.Data.SqlClient.SqlParameter("@absences", int.Parse(param2));
            // визов функції с параметрами
            form1.dataGridView11.DataSource = context.Inline_F01_Res.
                FromSqlInterpolated($"SELECT * FROM dbo.Inline_Function_N01 ({par_group}, {par_absences})").ToList();

            /* Інші приклади виконання SQL-запитів 
            * Всі приклади працездатні, можете виконувати їх по черзі 
            * Розкоментуйте потрібний рядок, запустіть програму та натисніть на формі першу кнопку "Викликати!" 
            * Опис прикладів див. у коментарі вище 
            */
            
            /* Приклад 1.0 */
            //form1.dataGridView11.DataSource = context.Students.FromSqlRaw("SELECT * FROM STUDENTS").ToList();

            /* Приклад 1.1 */
            //form1.dataGridView11.DataSource = context.Example12_Res.FromSqlRaw("SELECT Name, Surname FROM STUDENTS").ToList();

            /* Приклад 1.2 */
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
        * Створення та виклик власної функції користувача 
        * У БД створіть власну функцію користувача на мові Transact-SQL 
        * у відповідності з варіантом завдання 
        * Додаткові відомості та приклади функцій Transact-SQL див. у бібліотеці MSDN: 
        * https://msdn.microsoft.com/library/ms186755.aspx 
        * 
        * Для створення функції знайдіть список функцій БД (див. попереднє завдання), клацніть правою кнопкою на списку Functions 
        * та виберіть команду Add new \ Inline Function 
        * У вікні відредагуйте код SQL-запиту CREATE FUNCTION 
        * 
        * У методі Task12() запрограмуйте виклик цієї функції 
        * та прив'язку повернутих нею даних до компонента form1.dataGridView11 
        * Не забудьте створити клас для повернення результатів та включити його в контекст (див. приклади у п. 1.1a) 
        * Якщо другий параметр не потрібен - забіть на нього (він потрібен для прив'язки до форми, тому там два текстбокси) 
        */

        public void Task12(string param1, string param2)
        {
            form1.dataGridView11.DataSource = null;
        }

        /* TODO 1.3 
        * Створення та виклик власної табличної користувальницької функції 
        * У БД створіть власну функцію користувача на мові Transact-SQL 
        * у відповідності з варіантом завдання 
        * Не забудьте описати клас для структури вихідної таблиці 
        * Як приклад можна подивитися в БД функцію Table_Function_N0100 
        * У методі Task13() запрограмуйте виклик цієї функції 
        * та прив'язку повернутих нею даних до компонента form1.dataGridView11 
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

            // прив'язка методу чомусь не працює :(
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
        * Приклад виклику збереженої процедури StoredProc_N0100 
        * Зверніть увагу на отримання вихідного параметра, 
        * а також обробку винятків 
        * 
        * Для перегляду результатів на формі перейдіть на вкладку Виклик збережених процедур 
        * та натисніть першу кнопку Викликати! 
        */

        public int OutValue31 = -1;

        public void Task31(string param1, string param2, string param3)
        {
            try
            {

                var par_output = new Microsoft.Data.SqlClient.SqlParameter("@outparam", System.Data.SqlDbType.Int);
                par_output.Direction = System.Data.ParameterDirection.Output;

                // інтерполяція строк
                context.Database.ExecuteSqlInterpolated($"EXEC StoredProc_N0100 {param1}, {param2}, {param3}, {par_output} OUT");

                //оновлення даних на формі
                form1.Test_dataGridView.DataSource = context.TestTables.ToList();
                OutValue31 = (int)par_output.Value;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message+"\n\n"+ (e.InnerException != null ? e.InnerException.Message : ""));
            }
        }

        /* TODO 3.2 
        * Створення процедури, що зберігається у відповідності з варіантом завдання. 
        * У БД створіть власну процедуру, що зберігається на мові Transact-SQL 
        * у відповідності з варіантом завдання 
        * Додаткові відомості та приклади створення процедур, що зберігаються Transact-SQL 
        * див. у бібліотеці MSDN: 
        * https://msdn.microsoft.com/library/ms187926.aspx 
        * 
        * У методі Task32() запрограмуйте виклик цієї процедури, що зберігається. 
        * та оновлення даних з таблиці Test_Table у компоненті form1.Test_dataGridView 
        * Не забудьте отримати вихідний параметр 
        * Значення вихідного параметра помістіть у змінну OutValue22 
        * Реалізуйте обробку винятків 
        */

        public int OutValue32 = -1;

        public void Task32(string param1, string param2)
        {
            form1.Test_dataGridView.DataSource = null;
        }

    }
}
