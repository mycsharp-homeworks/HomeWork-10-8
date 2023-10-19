using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_10_8
{
    internal interface IManagerAccess
    {
        void SetName(string name);
        void SetSurname(string surname);
        void SetPatronymic(string patronymic);
        void SetPassportSeries(string passportSeries);
        void SetPassportNumber(string passportNumber);
    }
}
