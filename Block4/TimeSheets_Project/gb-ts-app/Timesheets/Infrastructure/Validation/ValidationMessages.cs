using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Infrastructure.Validation
{
    public static class ValidationMessages
    {
        public const string SheetAmountError = "Amount должен быть в диапазоне от 1 до 8 часов.";
        public const string RequestDateStartError = "Начальная дата должна быть раньше или равной дате окончания.";
        public const string RequestDateEndError = "Конечная дата должна быть позже или равной начальной дате.";
        public const string InvalidValue = "Некорректное значение.";


    }
}
