using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_SP_2022
{
    /* TODO 2.11
     * Клас для возврату результату скалярної функції
     * Функція Scalar_Function_N0100 повертає ціле число або NULL,
     * тому використовуэться Nullable<int>:
     * https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/builtin-types/nullable-value-types
     */
    public class IntScalar
    {
        public int? Result { get; set; }
    }

}
