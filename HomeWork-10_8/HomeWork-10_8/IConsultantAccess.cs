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
        string GetMobileNumber();
        string GetPassportSeries();
        string GetPassportNumber();
        void SetCellPhoneNumber(string cellPhoneNumber);
    }
}
