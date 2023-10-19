using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_10_8
{
    internal class Manager : Consultant, IManagerAccess
    {
        public Manager(Client client) : base(client)
        {
        }

        public override string GetPassportNumber()
        {
            return client.passportNumber;
        }

        public override string GetPassportSeries()
        {
            return client.passportSeries;
        }

        public void SetName(string name)
        {
            client.name = name;
        }

        public void SetPassportNumber(string passportNumber)
        {
            client.passportNumber = passportNumber;
        }

        public void SetPassportSeries(string passportSeries)
        {
            client.passportSeries = passportSeries;
        }

        public void SetPatronymic(string patronymic)
        {
            client.patronymic = patronymic;
        }

        public void SetSurname(string surname)
        {
            client.surname = surname;
        }
    }
}
