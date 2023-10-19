using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_10_8
{
    internal interface IConsultantAccess
    {
        string GetName();
        string GetSurname();
        string GetPatronymic();
        string GetCellPhoneNumber();
        string GetPassportSeries();
        string GetPassportNumber();
        void SetCellPhoneNumber(string cellPhoneNumber);
    }
}
